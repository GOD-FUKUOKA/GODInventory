using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GODInventory.NAFCO.EDI
{
    public class ReceivedCSVOrderHeadModel
    {
        Byte[] データID; //1 データID        3 1
        Byte[] 管理連番; //2 管理連番        13 4
        Byte[] システム管理日付; //3 システム管理日付 8 17
        Byte[] データ作成日; //4 データ作成日      8 25
        Byte[] データ作成時刻; //5 データ作成時刻     6 33
        Byte[] 出荷業務仕入先コード; //6 出荷業務仕入先コード 6 39
        Byte[] レコード件数; //7 レコード件数      8 45
        Byte[] レコード長; //8 レコード長       4 53
        Byte[] 予備; //9 予備              644 57
        byte[] nr;

        public List<ReceivedCSVOrderModel> models;

        public ReceivedCSVOrderHeadModel(StreamReader sr)
        {
            var columns = sr.ReadLine();
            string line;

            this.models = new List<ReceivedCSVOrderModel>(  );

            while ((line = sr.ReadLine()) != null && line != String.Empty)
            {
                models.Add(new ReceivedCSVOrderModel(line));                
            }
        }

        public int DetailCount
        {
            get
            {
                return models.Count;
            }
        }

        public List<ReceivedCSVOrderModel> Models
        {
            get { return this.models;  }
        }
    }
}
