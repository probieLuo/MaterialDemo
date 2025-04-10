namespace MaterialDemo.Models;
public class badgeUrls
{
    public string small { get; set; }
    public string large { get; set; }
    public string medium { get; set; }
}
public class clan
{
    public string tag { get; set; }
    public string name { get; set; }
    public int clanLevel { get; set; }
    public badgeUrls badgeUrls { get; set; }
}
public class iconUrls
{
    public string small { get; set; }
    public string tiny { get; set; }
    public string medium { get; set; }
}
public class league
{
    public int id { get; set; }
    public string name { get; set; }
    public iconUrls iconUrls { get; set; }
}
public class builderBaseLeague
{
    public int id { get; set; }
    public string name { get; set; }
}
public class bestSeason
{
    public string id { get; set; }
    public int rank { get; set; }
    public int trophies { get; set; }
}
public class currentSeason
{
    public int trophies { get; set; }
}
public class legendStatistics
{
    public int legendTrophies { get; set; }
    public bestSeason bestSeason { get; set; }
    public currentSeason currentSeason { get; set; }
}
public class achievements
{
    public string name { get; set; }
    public int stars { get; set; }
    public int value { get; set; }
    public int target { get; set; }
    public string info { get; set; }
    public string completionInfo { get; set; }
    public string village { get; set; }
}
public class elements
{
    public string type { get; set; }
    public int id { get; set; }
}
public class playerHouse
{
    public List<elements> elements { get; set; }
}
public class labels
{
    public int id { get; set; }
    public string name { get; set; }
    public iconUrls iconUrls { get; set; }
}
public class equipment
{
    public string name { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string village { get; set; }
}
public class heroes
{
    public string name { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public List<equipment> equipment { get; set; }
    public string village { get; set; }
}
public class heroEquipment
{
    public string name { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string village { get; set; }
}
public class spells
{
    public string name { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string village { get; set; }
}
public class troops
{
    public string name { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string village { get; set; }
}
public class Root
{
    public string tag { get; set; }
    public string name { get; set; }
    public int townHallLevel { get; set; }
    public int townHallWeaponLevel { get; set; }
    public int expLevel { get; set; }
    public int trophies { get; set; }
    public int bestTrophies { get; set; }
    public int warStars { get; set; }
    public int attackWins { get; set; }
    public int defenseWins { get; set; }
    public int builderHallLevel { get; set; }
    public int builderBaseTrophies { get; set; }
    public int bestBuilderBaseTrophies { get; set; }
    public string role { get; set; }
    public string warPreference { get; set; }
    public int donations { get; set; }
    public int donationsReceived { get; set; }
    public int clanCapitalContributions { get; set; }
    public clan clan { get; set; }
    public league league { get; set; }
    public builderBaseLeague builderBaseLeague { get; set; }
    public legendStatistics legendStatistics { get; set; }
    public List<achievements> achievements { get; set; }
    public playerHouse playerHouse { get; set; }
    public List<labels> labels { get; set; }
    public List<heroes> heroes { get; set; }
    public List<heroEquipment> heroEquipment { get; set; }
    public List<spells> spells { get; set; }
    public List<troops> troops { get; set; }
}