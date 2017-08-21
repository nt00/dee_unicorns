using UnityEngine;

public class Item 
{
    private int _id;
    private string _name;
    private int _clipsize;
    private float _damage;
    private float _firerate;
    private float _weaponrange;
    private int _weight;
    private string _ammotype;
    private Texture2D _icon;
    private string _modelname;


    public void ItemInformation(int id, string name, int clipsize, float damage, float firerate, float weaponrange, int weight, string ammotype, Texture2D icon, string modelname)
    {
        _id = id;
        _name = name;
        _clipsize = clipsize;
        _damage = damage;
        _firerate = firerate;
        _weaponrange = weaponrange;
        _weight = weight;
        _ammotype = ammotype;
        _icon = icon;
        _modelname = modelname;

    }

    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Clipsize
    {
        get { return _clipsize; }
        set { _clipsize = value; }
    }
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }

    }
    public float Firerate
    {
        get { return _firerate; }
        set { _firerate = value; }

    }
    public float Weaponrange
    {
        get { return _weaponrange; }
        set { _weaponrange = value; }

    }
    public int Weight
    {
        get { return _weight; }
        set { _weight = value; }

    }
    public string Ammotype
    {
        get { return _ammotype; }
        set { _ammotype = value; }

    }

    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }

    public string Modelname
    {
        get { return _modelname; }
        set { _modelname = value; }
    }

}
