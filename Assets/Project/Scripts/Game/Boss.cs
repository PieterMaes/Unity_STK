using System;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * Creates one wizards that drops cats
 * The way it works right now: every 50 points the wizard dies => new one spawn and is faster 
 */
public class Boss : MonoBehaviour
{
    //general 
    private float[] _coordinates;
    private float _leftCorner;
    private float _rightCorner;
    private float _interval;
    private float _position;
    private float _totalTime;
    private float _timeForMove;
    private bool _setWizardDropping;
    private bool _isDestroyed;
    private int _status;
    private int _tempScore;
    private int _highestScore;
    private int _xPosFloat;
    private float _speed;

    //variables to use for score
    private GameObject _text;
    private ScoreText _st;
    
    //used to check the state of the wizard
    private bool _hasArrived;
    private bool _isDropping;
    private bool _moveToRight;
    private bool _checkIfHit;
    
    //Instance of wizard, can be destroyed and reinitialized at will

    [Header("Boss")] 
    public GameObject wizard;
    public GameObject lavaOrb;
    public GameObject deadWizard;

    [Header("Spawn Object")] public GameObject cat;

    void Start()
    {
        //set tracking booleans right
        _hasArrived = true;
        _moveToRight = false;
        _isDestroyed = false;
        
        _text = GameObject.Find("ScoreText");
        _st = _text.transform.GetComponent<ScoreText>();
        _interval = 4;
        _speed = 0.1f;

        _leftCorner = -7.5f;
        _rightCorner = 7.5f;
        
        //Create initial wizard and set to position on screen
        wizard = Instantiate(wizard);
        _position = -7;
        wizard.transform.position = new Vector2(_position, 5);
        _checkIfHit = false;
        _tempScore = _st.GetScore();
        MoveWizard();
        //InvokeRepeating(nameof(MoveWizard), 1, _interval);
    }

    void Update()
    {
        // On every 25 score there is a wizard boss stage, killing the boss as soon
        // as possible is key for maintaining a 
        _timeForMove += Time.deltaTime;
        if (_highestScore < _st.GetScore()) _highestScore = _st.GetScore();
        if (_isDestroyed)
        {
            _isDestroyed = false;
            var nw = wizard.transform.position;
            Instantiate(deadWizard).transform.position = nw;
            Destroy(wizard);
            Destroy(deadWizard);
            wizard = Instantiate(wizard);
            wizard.GetComponent<BoxCollider2D>().enabled = true;
            wizard.transform.position = new Vector2(0, 5);
            if (_interval > .5) _interval *= 0.75f;
            else _interval *= .95f;
        }

        if (_timeForMove >= _interval)
        {
            _timeForMove = 0;
            MoveWizard();
        }
        if (_highestScore % 10 == 0 || _checkIfHit == false)
        {
            spawnOrbs();
            if (!_moveToRight)
            {
                if (wizard.transform.position.Equals(new Vector2(7f, 5)))
                {
                    
                    _moveToRight = true;
                    _setWizardDropping = true;
                    
                }
                else
                {
                    wizard.transform.position = Vector2.MoveTowards(wizard.transform.position,
                        new Vector2(7, 5), _speed);
                }
            }
            else
            {
                switch (_setWizardDropping)
                {
                    case true:
                        wizard.GetComponent<Wizard1>().setDropping();
                        _setWizardDropping = false;
                        _checkIfHit = false;
                        _tempScore = _st.GetScore();
                        _status = 1;
                        _totalTime = 0;
                        break;
                    case false:
                        if (!(_tempScore < _st.GetScore()))
                        {
                            if (_tempScore > _st.GetScore()) _tempScore = _st.GetScore();
                        }
                        else
                        {
                            //when wizard is hit, ideally this is replaced in wizard itself
                            //wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizardHurt;
                            _moveToRight = false;
                            _checkIfHit = true;
                            if(wizard.gameObject.GetComponent<Wizard1>().getHealth() == 0) _isDestroyed = true;
                        }

                        MyParabola();
                        break;
                }
            }
            //wizard.transform.position = 

        }
        else
        {
            var tempVec = new Vector2(_position, 4.2f + (Mathf.Sin(Time.time * 5) * 0.95f));
            wizard.transform.position = Vector2.MoveTowards(wizard.transform.position, tempVec, _speed);
            if ((!wizard.transform.position.Equals(tempVec) || (_hasArrived)) &&
                ((_hasArrived) || (!(_timeForMove >= _interval - 0.1f)))) return;
            var newCat = Instantiate(cat);
            newCat.transform.position = new Vector3(_position, 4.5f, -1);
            _hasArrived = true;
        }
    }
    

    private void MoveWizard()
    {

        /*
         *  Different cases as to not make wizard go out of range
         *  At the same time we also want the wizard to go more than
         *  3 horizontal spaces as to not make the game to easy
         */
        switch (_position)
        {
            case <= -3:
                _position = Random.Range(_position + 3, _rightCorner);
                break;
            case >= 3:
                _position = Random.Range(_leftCorner, _position - 3);
                break;
            case >= 0:
            case < 0:
                var tempPos = _position;
                _position = Random.Range(_leftCorner, _rightCorner);
                var diff = Math.Abs((tempPos - _position));
                switch (diff)
                {
                    case < 4 and >= 0 when tempPos < _position:
                        _position += (4 - diff);
                        break;
                    case < 4 and >= 0 when tempPos >= _position:
                        _position -= (4 - diff);
                        break;
                }
                break;
        }

        _hasArrived = false;

    }

    private void MyParabola(){
        
        
        // var targetPos = new Vector2(5, -3);
        // wizard.transform.position = Vector2.MoveTowards(wizard.transform.position, targetPos, 0.2f);
        //make wizard move left and right when he comes down.

        spawnOrbs();
        
        switch(_status)
        {
            case 1:
                var targetPos = new Vector2(6, -3);
                const float x0 = 7;
                const float x1 = 6;
                _xPosFloat = 6;
                const float  dist = x1 - x0;
                var nextX = Mathf.MoveTowards(wizard.transform.position.x, x1, 0.95f * Time.deltaTime);
                var baseY = Mathf.Lerp(5, -3, (nextX - x0) / dist);
                var arc = -4 * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
                var nextPos = new Vector2(nextX, baseY + arc);
                wizard.transform.position = Vector2.MoveTowards(wizard.transform.position, nextPos, _speed);
                // Do something when we reach the target
                if (wizard.transform.position.Equals(targetPos)) _status = 2;
                
                break;
            case 2:
                var newTempVec = new Vector2(_xPosFloat, -3 + (Mathf.Sin(Time.time * 5) * 0.95f));
                wizard.transform.position = Vector2.MoveTowards(wizard.transform.position, newTempVec, _speed);
                if (wizard.transform.position.x.Equals(newTempVec.x))
                {
                    _xPosFloat = -_xPosFloat;
                }
                break;
        }
    }

    private void spawnOrbs()
    {
        
        _totalTime += Time.deltaTime;
        if (!(_totalTime >= 1.400)) return;
        _totalTime = 0;
        Instantiate(lavaOrb).transform.position = new Vector2(Random.Range(-6,8), -5);

    }
    
}
