using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public int max_pool_size = 5;
    public GameObject _element;

    private List<GameObject> _available_items;//this saves the available items
    private List<GameObject> _items_in_use;//this saves the itens that right now are used
    private Vector2 not_visible_position = new Vector2(-1000, -1000);//position out of the screen to move the object just in case

    void Awake()
    {
        _available_items = new List<GameObject>();
        _items_in_use = new List<GameObject>();

        //in the start, we fill the pool
        for(int i = 0; i < max_pool_size; ++i)
        {
            GameObject copy = Instantiate(_element);
            copy.transform.position = not_visible_position;//we move to the not vivible position
            copy.transform.parent = this.transform;//we make the pool the parent of the object
            copy.name += "child_" + i;//we change the name, so it can be easy to follow in the Editor
            copy.SetActive(false);//we make the object disabled
            _available_items.Add(copy);//we add the item to the list of available items, so it can be used 
        }
    }

    /// <summary>
    /// this method will return an item, if there are no availables items, it will return false
    /// </summary>
    /// <param name="new_object">An object from the pool </param>
    /// <returns>True if there is available items, if not, it will return false</returns>
    public bool GetItem(out GameObject new_object)
    {
        new_object = null;
        if(_available_items.Count >0)
        {
            //here there are available items
            new_object = _available_items[0];//we get the first item
            _items_in_use.Add(new_object);//update the list of items in use
            _available_items.RemoveAt(0);//we remove this item from available items, so no one will get it again until it will return to the pool
            return true;
        }
        //if we are here, there are no elements in the available items list, so we return false
        return false;
    }

    /// <summary>
    /// Here where return and object to the pool
    /// </summary>
    /// <param name="new_object"></param>
    public void ReturnItem(GameObject new_object)
    {
        _items_in_use.Remove(new_object);//we remove the item from the list of items in use
        _available_items.Add(new_object);//we add the item to the items that can be used
        new_object.transform.position = not_visible_position;//we move the item to the position of not wisible, just in case
        new_object.transform.rotation = Quaternion.Euler(0, 0, 0);//we set the rotation to 0 just in case
        new_object.SetActive(false);//we set to no active, so it will be not visible and the controlleres wont be called
    }
}
