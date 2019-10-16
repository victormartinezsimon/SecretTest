using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int max_pool_size = 5;
    public GameObject _element;

    private List<GameObject> _available_items;
    private List<GameObject> _items_in_use;
    private Vector2 not_visible_position = new Vector2(-1000, -1000);

    void Awake()
    {
        _available_items = new List<GameObject>();
        _items_in_use = new List<GameObject>();
        //in the start, we fill the pool
        for(int i = 0; i < max_pool_size; ++i)
        {
            GameObject copy = Instantiate(_element);
            copy.transform.position = not_visible_position;
            copy.transform.parent = this.transform;
            copy.name = "child_" + i;
            copy.SetActive(false);
            _available_items.Add(copy);
        }
    }

    public bool getItem(out GameObject new_object)
    {
        new_object = null;
        if(_available_items.Count >0)
        {
            new_object = _available_items[0];
            _items_in_use.Add(new_object);
            _available_items.RemoveAt(0);
            return true;
        }
        //if we are here, there are no elements in the available items list, so we return false
        return false;
    }

    public void returnItem(GameObject new_object)
    {
        _items_in_use.Remove(new_object);
        _available_items.Add(new_object);
        new_object.transform.position = not_visible_position;
        new_object.transform.rotation = Quaternion.Euler(0, 0, 0);//we set the rotation to 0 just in case
        new_object.SetActive(false);
    }
}
