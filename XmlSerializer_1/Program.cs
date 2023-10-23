using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;             // 참조추가


public class Program
{
    static void SerializeToXml(Scenarios a_scenarios, string output_path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Scenarios));
        using (StreamWriter writer = new StreamWriter(output_path))
        {
            serializer.Serialize(writer, a_scenarios);
        }
    }

    static Scenarios DeserializeFromXml(string inputPath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Scenarios));
        using (StreamReader reader = new StreamReader(inputPath))
        {
            return (Scenarios)serializer.Deserialize(reader);
        }
    }

    static void Main(string[] args)
    {
        // XML 파일로 만들기
        Scenarios scenarios = new Scenarios
        {
            Name = "TEST2",
            Desc = "고정익 아군기 1대, 불명기 1대",
            Time = DateTime.Parse("2022-03-10 17:50:50"),
            Version = 1.11,
            Radiation = 0,
            CrashCheck = 0,
            LosCheck = 0
        };

        // Populate the offense scenario
        scenarios.OffenseScenario = new OffenseScenario
        {
            Name = "Offense Scenario",
            Desc = "공격시나리오"
        };

        // Populate the formation and its ATSs
        scenarios.OffenseScenario.Formation = new Formation
        {
            Id = 0,
            AtsNo = 1,
            AtsList = new List<Ats>
            {
                new Ats
                {
                    Id = 1,
                    Kind = 1,
                    RouteId = 1,
                    Director = 0,
                    Parameter = "MIG-21MF",
                    IsSpl = 0,
                    RcsFluctuation = 0,
                    Iff = 1,
                    Time = 0,
                    Jamming = 0,
                    Crash = "",
                    Evasion = "",
                    AttackMode = "",
                    Radius = 0,
                    X = 37.675701,
                    Y = 128.286455,
                    Z = 1063.063964,
                    Dx = 0.0,
                    Dy = 0.0,
                    Dz = 0.0
                },
                new Ats
                {
                    Id = 1,
                    Kind = 1,
                    RouteId = 1,
                    Director = 0,
                    Parameter = "MIG-21MF",
                    IsSpl = 0,
                    RcsFluctuation = 0,
                    Iff = 1,
                    Time = 0,
                    Jamming = 0,
                    Crash = "",
                    Evasion = "",
                    AttackMode = "",
                    Radius = 0,
                    X = 37.675701,
                    Y = 128.286455,
                    Z = 1063.063964,
                    Dx = 0.0,
                    Dy = 0.0,
                    Dz = 0.0
                },
                new Ats
                {
                    Id = 1,
                    Kind = 1,
                    RouteId = 1,
                    Director = 0,
                    Parameter = "MIG-21MF",
                    IsSpl = 0,
                    RcsFluctuation = 0,
                    Iff = 1,
                    Time = 0,
                    Jamming = 0,
                    Crash = "",
                    Evasion = "",
                    AttackMode = "",
                    Radius = 0,
                    X = 37.675701,
                    Y = 128.286455,
                    Z = 1063.063964,
                    Dx = 0.0,
                    Dy = 0.0,
                    Dz = 0.0
                },
                new Ats
                {
                    Id = 1,
                    Kind = 1,
                    RouteId = 1,
                    Director = 0,
                    Parameter = "MIG-21MF",
                    IsSpl = 0,
                    RcsFluctuation = 0,
                    Iff = 1,
                    Time = 0,
                    Jamming = 0,
                    Crash = "",
                    Evasion = "",
                    AttackMode = "",
                    Radius = 0,
                    X = 37.675701,
                    Y = 128.286455,
                    Z = 1063.063964,
                    Dx = 0.0,
                    Dy = 0.0,
                    Dz = 0.0
                },
            }
        };

        scenarios.OffenseScenario.Routes = new List<Route>
        {

        };
    }
}

[XmlRoot("scenarios")]
class Scenarios
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("desc")]
    public string Desc { get; set; }

    [XmlAttribute("time")]
    public DateTime Time { get; set; }

    [XmlAttribute("version")]
    public double Version { get; set; }

    [XmlAttribute("radiation")]
    public int Radiation { get; set; }

    [XmlAttribute("crash_check")]
    public int CrashCheck { get; set; }

    [XmlAttribute("los_check")]
    public int LosCheck { get; set; }

    public OffenseScenario OffenseScenario { get; set; }
    public DefenseScenario DefenseScenario { get; set; }

}

class OffenseScenario
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("desc")]
    public string Desc { get; set; }

    [XmlElement("formation")]
    public Formation Formation { get; set; }

    [XmlElement("route")]
    public List<Route> Routes { get; set; }
}

class Formation
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("ats_no")]
    public int AtsNo { get; set; }

    [XmlElement("ats")]
    public List<Ats> AtsList { get; set; }
}


class Ats
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("kind")]
    public int Kind { get; set; }

    [XmlAttribute("route_id")]
    public int RouteId { get; set; }

    [XmlAttribute("director")]
    public int Director { get; set; }

    [XmlAttribute("parameter")]
    public string Parameter { get; set; }

    [XmlAttribute("is_spl")]
    public int IsSpl { get; set; }

    [XmlAttribute("rcs_fluctuation")]
    public int RcsFluctuation { get; set; }

    [XmlAttribute("iff")]
    public int Iff { get; set; }

    [XmlAttribute("time")]
    public int Time { get; set; }

    [XmlAttribute("jamming")]
    public int Jamming { get; set; }

    [XmlAttribute("crash")]
    public string Crash { get; set; }

    [XmlAttribute("evasion")]
    public string Evasion { get; set; }

    [XmlAttribute("attackmode")]
    public string AttackMode { get; set; }

    [XmlAttribute("radius")]
    public double Radius { get; set; }

    [XmlAttribute("x")]
    public double X { get; set; }

    [XmlAttribute("y")]
    public double Y { get; set; }

    [XmlAttribute("z")]
    public double Z { get; set; }

    [XmlAttribute("dx")]
    public double Dx { get; set; }

    [XmlAttribute("dy")]
    public double Dy { get; set; }

    [XmlAttribute("dz")]
    public double Dz { get; set; }
}

class Route
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlElement("waypoint")]
    public List<Waypoint> Waypoints { get; set; }
}

class Waypoint
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("type")]
    public int Type { get; set; }
    [XmlAttribute("mission")]
    public int Mission { get; set; }
    [XmlAttribute("speed")]
    public double Speed { get; set; }
    [XmlAttribute("x")]
    public double X { get; set; }
    [XmlAttribute("y")]
    public double Y { get; set; }
    [XmlAttribute("z")]
    public double Z { get; set; }
    [XmlAttribute("orbit_radius")]
    public double OrbitRadius { get; set; }
    [XmlAttribute("hovering")]
    public double Hovering { get; set; }
}


public class DefenseScenario
{
    [XmlAttribute("name")]
    public string Name { get; set; }

    [XmlAttribute("desc")]
    public string Desc { get; set; }

    [XmlElement("mfr")]
    public List<Mfr> Mfrs { get; set; }

    [XmlElement("lchr")]
    public List<Lchr> Lchrs { get; set; }

    [XmlElement("fcc")]
    public Fcc Fcc { get; set; }

    [XmlElement("ecs")]
    public Ecs Ecs { get; set; }
}


public class Mfr
{
    [XmlAttribute("id")]
    public int Id { get; set; }
    [XmlAttribute("kind")]
    public int Kind { get; set; }
    [XmlAttribute("x")]
    public double X { get; set; }
    [XmlAttribute("y")]
    public double Y { get; set; }
    [XmlAttribute("z")]
    public double Z { get; set; }
    [XmlAttribute("op_mode")]
    public int OpMode { get; set; }
    [XmlAttribute("detect_mode")]
    public int DetectMode { get; set; }
    [XmlAttribute("radiation")]
    public int Radiation { get; set; }
    [XmlAttribute("azimuth")]
    public double Azimuth { get; set; }
    [XmlAttribute("elevation")]
    public double Elevation { get; set; }
}

public class Lchr
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("kind")]
    public int Kind { get; set; }

    [XmlAttribute("roll")]
    public double Roll { get; set; }

    [XmlAttribute("pitch")]
    public double Pitch { get; set; }

    [XmlAttribute("azimuth")]
    public double Azimuth { get; set; }

    [XmlAttribute("x")]
    public double X { get; set; }

    [XmlAttribute("y")]
    public double Y { get; set; }

    [XmlAttribute("z")]
    public double Z { get; set; }

    [XmlAttribute("state")]
    public int State { get; set; }

    [XmlAttribute("msl_link")]
    public string MslLink { get; set; }

    [XmlAttribute("msl_type")]
    public string MslType { get; set; }

    [XmlAttribute("msl_SAU")]
    public string MslSAU { get; set; }

    [XmlAttribute("parameter")]
    public string Parameter { get; set; }
}

public class Fcc
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("x")]
    public double X { get; set; }

    [XmlAttribute("y")]
    public double Y { get; set; }

    [XmlAttribute("z")]
    public double Z { get; set; }

    [XmlAttribute("address")]
    public int Address { get; set; }

    [XmlAttribute("engagement_mode")]
    public int EngagementMode { get; set; }

    [XmlAttribute("operation_mode")]
    public int OperationMode { get; set; }

    [XmlAttribute("defense_state")]
    public int DefenseState { get; set; }

    [XmlAttribute("edcode")]
    public int EdCode { get; set; }
}

public class Ecs
{
    [XmlAttribute("id")]
    public int Id { get; set; }

    [XmlAttribute("x")]
    public double X { get; set; }

    [XmlAttribute("y")]
    public double Y { get; set; }

    [XmlAttribute("z")]
    public double Z { get; set; }
}