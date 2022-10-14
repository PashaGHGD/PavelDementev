using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void SkillDelegate();
public class MyDelegate : MonoBehaviour {
    private SkillsPlayer _skillsPlayer = new SkillsPlayer();
    private PlayerMove _playerMove;
    private SkillDelegate _skillSpeedX2;
    private SkillDelegate _skillStartSpeed;
    private SkillDelegate _skill2;




    void Start() {


        _playerMove = FindObjectOfType<PlayerMove>();

        try {
            _skillSpeedX2 = _playerMove.SkillSpeedUp;
            _skillStartSpeed = _playerMove.SkillSpeedDown;
        } catch (System.Exception e) {

            Debug.Log(e);

        } finally {

            _skill2 = _skillsPlayer.Slills1;

        }

    }


    void Update() {

        StartSkill();
        //if (Input.GetMouseButton(1)) {

        //    //  _skill1?.Invoke();
        //    _skill2?.Invoke();

        //}

    }

    public void StartSkill() {

        if (Input.GetMouseButtonDown(0)) {

            _skillSpeedX2?.Invoke();
            _skill2?.Invoke();

        } else if(Input.GetMouseButtonUp(0)) {

            _skillStartSpeed?.Invoke();


        }

    }
}



