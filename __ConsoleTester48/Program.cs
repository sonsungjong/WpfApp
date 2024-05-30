using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace __ConsoleTester48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""EUC-KR""?>
<scenario name=""UAEMain3"" desc=""UAEMain3"" time=""2024-04-29 16:16:11"" los_check=""1"">
    <offense_scenario>
        <ats>
            <ATS>
                <id>1</id>
                <kind>1</kind>
                <route_id>1</route_id>
                <parameter>param1</parameter>
                <iff>1</iff>
                <time>123.456</time>
                <jamming>0</jamming>
                <jammer_target_mfr_id>0</jammer_target_mfr_id>
                <latitude>24.12345</latitude>
                <longitude>55.12345</longitude>
                <altitude>100.0</altitude>
                <iff_data>
                    <mode1>mode1</mode1>
                    <mode2>mode2</mode2>
                    <mode3>mode3</mode3>
                    <mode4>mode4</mode4>
                    <mode5>mode5</mode5>
                    <mode5Pin>pin</mode5Pin>
                    <mode5NO>no</mode5NO>
                </iff_data>
                <jammer>
                    <id>1</id>
                    <type>1</type>
                    <range>100.0</range>
                    <noj_param>param</noj_param>
                </jammer>
            </ATS>
        </ats>
        <ats>
            <ATS>
                <id>2</id>
                <kind>1</kind>
                <route_id>1</route_id>
                <parameter>param2</parameter>
                <iff>1</iff>
                <time>55.1123</time>
                <jamming>0</jamming>
                <jammer_target_mfr_id>0</jammer_target_mfr_id>
                <latitude>99.99</latitude>
                <longitude>88.88</longitude>
                <altitude>300.0</altitude>
                <iff_data>
                    <mode1>mode1</mode1>
                    <mode2>mode2</mode2>
                    <mode3>mode3</mode3>
                    <mode4>mode4</mode4>
                    <mode5>mode5</mode5>
                    <mode5Pin>pin</mode5Pin>
                    <mode5NO>no</mode5NO>
                </iff_data>
                <jammer>
                    <id>1</id>
                    <type>1</type>
                    <range>100.0</range>
                    <noj_param>param</noj_param>
                </jammer>
            </ATS>
        </ats>
        <route>
            <Route>
                <id>1</id>
                <waypoint>
                    <CsXmlWaypoint>
                        <id>1</id>
                        <type>1</type>
                        <mission>1</mission>
                        <speed>1.0</speed>
                        <latitude>24.12345</latitude>
                        <longitude>55.12345</longitude>
                        <altitude>100.0</altitude>
                        <orbit_radius>50.0</orbit_radius>
                    </CsXmlWaypoint>
                </waypoint>
            </Route>
        </route>
    </offense_scenario>
    <defense_scenario>
        <ecs>
            <Ecs>
                <id>3</id>
                <latitude>24.485344</latitude>
                <longitude>55.573112</longitude>
                <altitude>254.000000</altitude>
                <main_fire_direction>0.000000</main_fire_direction>
                <MDIL>20992</MDIL>
                <TADIL_J>10</TADIL_J>
                <use_order>1</use_order>
                <mfr>
                    <Mfr>
                        <id>5</id>
                        <latitude>24.319113</latitude>
                        <longitude>56.970665</longitude>
                        <altitude>0.000000</altitude>
                        <radar_mode>6</radar_mode>
                    </Mfr>
                    <Mfr>
                        <id>6</id>
                        <latitude>24.038103</latitude>
                        <longitude>52.527012</longitude>
                        <altitude>20.000000</altitude>
                        <radar_mode>1</radar_mode>
                    </Mfr>
                </mfr>
                <vls>
                    <Vls>
                        <id>1</id>
                        <latitude>24.12345</latitude>
                        <longitude>55.12345</longitude>
                        <altitude>100.0</altitude>
                        <state>1</state>
                        <msl_link>link</msl_link>
                        <msl_type>type</msl_type>
                        <msl_SAU>sau</msl_SAU>
                        <parameter>param</parameter>
                    </Vls>
                </vls>
            </Ecs>
        </ecs>
        <icc>
            <Icc>
                <id>1</id>
                <latitude>24.12345</latitude>
                <longitude>55.12345</longitude>
                <altitude>100.0</altitude>
                <MDIL>1</MDIL>
                <TADIL_J>1</TADIL_J>
            </Icc>
        </icc>
        <ewr>
            <Ewr>
                <id>1</id>
                <latitude>24.12345</latitude>
                <longitude>55.12345</longitude>
                <altitude>100.0</altitude>
                <radar_mode>1</radar_mode>
            </Ewr>
        </ewr>
        <c2>
            <C2>
                <id>1</id>
                <latitude>24.12345</latitude>
                <longitude>55.12345</longitude>
                <altitude>100.0</altitude>
                <MDIL>1</MDIL>
                <TADIL_J>1</TADIL_J>
            </C2>
        </c2>
        <upsyscmd>
            <Upsyscmd>
                <id>1</id>
                <target_track_id>1</target_track_id>
                <send_own_addr>1</send_own_addr>
                <fire_cmd>1</fire_cmd>
                <latitude>24.12345</latitude>
                <longitude>55.12345</longitude>
            </Upsyscmd>
        </upsyscmd>
    </defense_scenario>
    <region_scenario file_name=""UAEMain3_region""/>
    <draw_scenario file_name=""UAEMain3_draw""/>
</scenario>";
            ClassTest test = new ClassTest();
            CsXmlScenario scenario = test.deserializeScenarioString(xml);

            Console.WriteLine($"Name: {scenario.name}, Desc: {scenario.desc}, Time: {scenario.time}, Los Check: {scenario.los_check}");
            Console.WriteLine("end");
        }
    }

    class ClassTest
    {
        public CsXmlScenario deserializeScenarioString(string strUnicodeXML)
        {
            using (StringReader reader = new StringReader(strUnicodeXML))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CsXmlScenario));
                CsXmlScenario test = new CsXmlScenario();
                test = (CsXmlScenario)serializer.Deserialize(reader);       // 클래스로 반환
                return test;
            }
        }
    }

    [Serializable, XmlRoot("scenario")]
    public class CsXmlScenario
    {
        [XmlAttribute("name")]
        public string name;
        [XmlAttribute("desc")]
        public string desc;
        [XmlAttribute("time")]
        public string time;
        [XmlAttribute("los_check")]
        public int los_check;

        public CsXmlOffenseScenario offense_scenario;
        public CsXmlDefenseScenario defense_scenario;
        public CsXmlRegionScenario region_scenario;
        public CsXmlDrawScenario draw_scenario;
    }

    [Serializable]
    public class CsXmlOffenseScenario
    {
        public List<ATS> ats;
        public List<Route> route;
    }

    [Serializable]
    public class CsXmlDefenseScenario
    {
        public List<Ecs> ecs;
        public List<Icc> icc;
        public List<Ewr> ewr;
        public List<C2> c2;
        public List<Upsyscmd> upsyscmd;
    }

    [Serializable]
    public class CsXmlRegionScenario
    {
        public string file_name;            // 프레임워크 통신배열을 초과해서 별도 처리 필요
    }

    [Serializable]
    public class CsXmlDrawScenario
    {
        public string file_name;            // 프레임워크 통신배열을 초과해서 별도 처리 필요
    }

    [Serializable]
    public class ATS
    {
        public int id;
        public int kind;
        public int route_id;
        public string parameter;
        public int iff;
        public double time;
        public int jamming;
        public int jammer_target_mfr_id;
        public double latitude;
        public double longitude;
        public double altitude;
        public CsXmlIFFData iff_data;
        public CsXmlJammer jammer;
    }

    [Serializable]
    public class CsXmlIFFData
    {
        public string mode1;
        public string mode2;
        public string mode3;
        public string mode4;
        public string mode5;
        public string mode5Pin;
        public string mode5NO;
    }

    [Serializable]
    public class CsXmlJammer
    {
        public int id;
        public int type;
        public double range;
        public string noj_param;
    }

    [Serializable]
    public class Route
    {
        public int id;
        public List<CsXmlWaypoint> waypoint;
    }

    [Serializable]
    public class CsXmlWaypoint
    {
        public int id;
        public int type;
        public int mission;
        public double speed;
        public double latitude;
        public double longitude;
        public double altitude;
        public double orbit_radius;
    }

    [Serializable]
    public class Ecs
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public double main_fire_direction;
        public ushort MDIL;
        public ushort TADIL_J;
        public int use_order;
        public List<Mfr> mfr;
        public List<Vls> vls;
    }

    [Serializable]
    public class Mfr
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public int radar_mode;
    }

    [Serializable]
    public class Vls
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public int state;
        public string msl_link;
        public string msl_type;
        public string msl_SAU;
        public string parameter;
    }

    [Serializable]
    public class Icc
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public short MDIL;
        public short TADIL_J;
    }

    [Serializable]
    public class Ewr
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public int radar_mode;
    }

    [Serializable]
    public class C2
    {
        public int id;
        public double latitude;
        public double longitude;
        public double altitude;
        public short MDIL;
        public short TADIL_J;
    }

    [Serializable]
    public class Upsyscmd
    {
        public int id;
        public int target_track_id;
        public int send_own_addr;
        public short fire_cmd;
        public double latitude;
        public double longitude;
    }
}
