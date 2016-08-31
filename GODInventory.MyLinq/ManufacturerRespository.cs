using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{

    public class ManufactureRespository { 

        static List<MockEntity> list;
        static Dictionary<int, int> codeDict;
        static ManufactureRespository() {

            list = new List<MockEntity>(10);
            list.Add(new MockEntity { Id = 1, FullName = "青島華天" });

            codeDict = new Dictionary<int, int>();

            InitializeCodeDict();
        }
        public static List<MockEntity> ToList()
        {

            return list;
        }

        public static Dictionary<int, int> CodeDict {
            get { return codeDict; }
        }

        public static string OptionTextAll
        {
            get { return "全部"; }
        }

        private static void InitializeCodeDict()
        {

            codeDict[7000] = 100300;
            codeDict[7001] = 100301;
            codeDict[7002] = 100302;
            codeDict[7003] = 100303;
            codeDict[7004] = 100304;
            codeDict[7005] = 100305;
            codeDict[7006] = 100306;
            codeDict[7007] = 100307;
            codeDict[7008] = 100308;
            codeDict[7009] = 100309;
            codeDict[7010] = 100310;
            codeDict[7011] = 100311;
            codeDict[7012] = 100312;
            codeDict[7013] = 100313;
            codeDict[7014] = 100314;
            codeDict[7015] = 100315;
            codeDict[7016] = 100316;
            codeDict[7017] = 100317;
            codeDict[7018] = 100318;
            codeDict[7019] = 100319;
            codeDict[7020] = 100320;
            codeDict[7021] = 100321;
            codeDict[7022] = 100322;
            codeDict[7023] = 100323;
            codeDict[7024] = 100324;
            codeDict[7025] = 100325;
            codeDict[7026] = 100326;
            codeDict[7027] = 100327;
            codeDict[7028] = 100328;
            codeDict[7029] = 100329;
            codeDict[7030] = 100330;
            codeDict[7031] = 100331;
            codeDict[7032] = 100332;
            codeDict[7033] = 100333;
            codeDict[7034] = 100334;
            codeDict[7035] = 100335;
            codeDict[7036] = 100336;
            codeDict[7037] = 100337;
            codeDict[7038] = 100338;
            codeDict[7039] = 100339;
            codeDict[7040] = 100340;
            codeDict[7041] = 100341;
            codeDict[7042] = 100342;
            codeDict[7043] = 100343;
            codeDict[7044] = 100344;
            codeDict[7045] = 100345;
            codeDict[7046] = 100346;
            codeDict[7047] = 100347;
            codeDict[7048] = 100348;
            codeDict[7049] = 100349;
            codeDict[7050] = 100350;
            codeDict[7051] = 100351;
            codeDict[7052] = 100352;
            codeDict[7053] = 100353;
            codeDict[7054] = 100354;
            codeDict[7055] = 100355;
            codeDict[7056] = 100356;
            codeDict[7057] = 100357;
            codeDict[7058] = 100358;
            codeDict[7059] = 100359;
            codeDict[7060] = 100360;
            codeDict[7061] = 100361;
            codeDict[7062] = 100362;
            codeDict[7063] = 100363;
            codeDict[7064] = 100364;
            codeDict[7065] = 100365;
            codeDict[7066] = 100366;
            codeDict[7067] = 100367;
            codeDict[7068] = 100368;
            codeDict[7069] = 100369;
            codeDict[7070] = 100370;
            codeDict[7071] = 100371;
            codeDict[7072] = 100372;
            codeDict[7073] = 100373;
            codeDict[7074] = 100374;

        }
    }
}
