
using UnityEngine;

public class BulletController
{
    private Vector3 _velosity;
    private BulletView _bulletView;

    public BulletController( BulletView bulletView) {
        
        _bulletView = bulletView;
        Active(false);

    }
    public void Active(bool val) {

        _bulletView.gameObject.SetActive(val);

    }
    public void SetVelosity(Vector3 velosity) {
        _velosity = velosity;
        float angle = Vector3.Angle(Vector3.left,_velosity);
        Vector3 axis = Vector3.Cross(Vector3.left, _velosity);
        _bulletView._transform.rotation = Quaternion.AngleAxis(angle,axis);
    }

    public void  Trow(Vector3 position, Vector3 velosity) {

        _bulletView._transform.position = position;
        SetVelosity(_velosity);
        _bulletView._rb.velocity = Vector2.zero;
        _bulletView._rb.angularVelocity = 0;
        Active(true);
        _bulletView._rb.AddForce(velosity, ForceMode2D.Impulse);

    }

}
