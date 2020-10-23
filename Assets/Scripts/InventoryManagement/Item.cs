[System.Serializable]
public class Item
{
    public int id;
    public string location;
    public string name;
    public string type; 
    public int damage;
    public int defence;
    public int consumption;
    public int gain;
    public bool stackable;
    public int storage;
    public int cost;
   
    // constructor for empty, used only for testing or delete
    public Item()
    {
        this.id = -1;
    }
    // constructor with parameters for an item
    public Item(int id, string location, string name, string type, int damage, int defence, int consumption, 
        int gain, bool stackable, int storage, int cost)
    {
        this.id = id;
        this.location = location;
        this.name = name;
        this.type = type;
        this.damage = damage;
        this.defence = defence;
        this.consumption = consumption;
        this.gain = gain;
        this.stackable = stackable;
        this.storage = storage;
        this.cost = cost;
    }

    public string ToString()
    {
        return id + ", " + location + ", "+ name + ", " + type + ", " + damage + ", " 
            + defence + ", "+ consumption + ", " + gain + ", " + stackable +", " +storage + ", " +cost;
    }
}

/*
public class Root
{
    public List<Item> Items;
}
*/

/*
public int ID
{
    get { return id; }   // get method
    set { id = value; }  // set method
}
public string Name
{
    get { return name; }   // get method
    set { name = value; }  // set method
}
public string Type
{
    get { return type; }   // get method
    set { type = value; }  // set method
}
public int Damage
{
    get { return damage; }   // get method
    set { damage = value; }  // set method
}
public int Consumption
{
    get { return consumption; }   // get method
    set { consumption = value; }  // set method
}
public int Gain
{
    get { return gain; }   // get method
    set { gain = value; }  // set method
}
*/
// empty constructor
/*
public Item()
    {
        this.id = 0;
        this.name = null;
        this.type = null;
        this.damage = 0;
        this.consumption = 0;
        this.gain = 0;
    }
    // constructor with parameters for an item
    public Item(int id, string name, string type, int damage, int consumption, int gain)// : base(ID, Name, Type, Damage, Consumption, Gain)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.damage = damage;
        this.consumption = consumption;
        this.gain = gain;
    }

    public  string ToString()
    {
        return id + ", "+ name + ", "+ type + ", " + damage + ", " + consumption + ", " + gain;
    }

}*/
