namespace knightTale.Models
{
  public class Knight
  {
    public string Name { get; set; }

    public string Kingdom { get; set; }

    public int Age { get; set; }

    public int Id { get; set; }


  }
}


// NOTE If you want to use a bool, this will be needed for the PUT in the services It actually made a choice to flip this value so someone actually set it. 
// private bool _deceased;
// internal public bool DeceasedWasSet {get; set;}
// public bool Decease {
// _deceased = value;
// DeceasedWasSet = true;
// }
