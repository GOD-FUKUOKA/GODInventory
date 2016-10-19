using GODInventory.MyLinq;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace GODInventory.ViewModel.EDI
{
    public class ReceivedCSVOrderModel
    {
        
        //1 データID       3 1
        //2 管理連番        13 4
        //3 システム管理日付 8 17
        //4 データ作成日      8 25
        //5 データ作成時刻 6 33
        //6 法人 コード  2 39
        //7 法人名漢字   20 41
        //8 法人名 カナ  15 61
        //9 店舗 コード  3 76

        //10 店舗名漢字  20 79
        //11 店舗名カナ  15  99
        //12 部門 コード 2   114
        //13 部門名漢字  20  116
        //14 部門名カナ  15  136
        //15 仕入先コード 6   151
        //16 仕入先名漢字 20  157
        //17 仕入先名カナ 15  177
        //18 支払仕入先コード   6   192
        //19 支払仕入先名漢字   20  198
        //20 支払仕入先名カナ   15  218
        //21 出荷業務仕入先コード 6   233
        //22 伝票区分   2   239
        //23 赤黒区分   1   241

        //24 伝票番号   8   242
        //25 行番号    2   250
        //26 元伝票番号  8   252
        //27 発生日        8   260
        //28 仕入計上日  8   268
        //29 商品コード区分   1   276
        //30 ＪＡＮコード     13  277
        //31 商品 コード     8   290
        //32 オプション使用欄   20  298
        //33 ＧＴＩＮ       14  318
        //34 品名漢字       20  332
        //35 品名 カナ      25  352
        //36 規格名漢字      20  377
        //37 規格名カナ      25  397
        //38 数量             6   422
        //39 総額取引区分     1   428

        //40 原単価(税抜 )   9   429
        //41 原単価(税込 )   9   438
        //42 原価金額(税抜 )  9   447
        //43 原価金額(税込 )  9   456
        //44 税区分        1   465
        //45 税率         4   466
        //46 税額         9   470
        //47 売単価（税抜  ）  7   479
        //48 売単価（税込  ）  7   486
        //49 特価区分         1   493
        //50 PB区分         1 494
        //51 原価区分       1   495
        //52 受領区分       2   496
        //53 理由区分       2   498
        //54 理由コード      2   500
        //55 理由漢字       20  502
        //56 連絡事項１      30  522
        //57 連絡事項２      30  552
        //58 納品先店舗コード   3   582

        //59 納品先店舗名漢字   20  585
        //60 納品先店舗名カナ   15  605
        //61 センター経由区分   1   620
        //62 センターコード    5   621
        //63 センター名漢字    20  626
        //64 予備     55 646

        string データID;
        string 管理連番;
        string システム管理日付;
        string データ作成日;
        string データ作成時刻;
        string 法人コード;
        string 法人名漢字;
        string 法人名カナ;
        string 店舗コード;

        string 店舗名漢字;
        string 店舗名カナ;
        string 部門コード;
        string 部門名漢字;
        string 部門名カナ;
        string 仕入先コード;
        string 仕入先名漢字;
        string 仕入先名カナ;
        string 支払仕入先コード;
        string 支払仕入先名漢字;
        string 支払仕入先名カナ;
        string 出荷業務仕入先コード;
        string 伝票区分;
        string 赤黒区分;

        string 伝票番号;
        string 行番号;
        string 元伝票番号;
        string 発生日;
        string 仕入計上日;
        string 商品コード区分;
        string ＪＡＮコード;
        string 商品コード;
        string オプション使用欄;
        string ＧＴＩＮ;
        string 品名漢字;
        string 品名カナ;
        string 規格名漢字;
        string 規格名カナ;
        string 数量;
        string 総額取引区分;

        string 原単価_税抜_;
        string 原単価_税込_;
        string 原価金額_税抜_;
        string 原価金額_税込_;
        string 税区分;
        string 税率;
        string 税額;
        string 売単価_税抜_;
        string 売単価_税込_;
        string 特価区分;
        string PB区分;
        string 原価区分;
        string 受領区分;
        string 理由区分;
        string 理由コード;
        string 理由漢字;
        string 連絡事項１;
        string 連絡事項２;
        string 納品先店舗コード;

        string 納品先店舗名漢字;
        string 納品先店舗名カナ;
        string センター経由区分;
        string センターコード;
        string センター名漢字;
        string 予備;
        string nr;

        v_receivedorder entity;

        public ReceivedCSVOrderModel(string line) 
        {           
            var untrimFields = line.Split(',');
            var fields = untrimFields.Select(s => s.Trim('"')).ToList();
            Debug.Assert( fields.Count() == 60);


            this.データ作成日 = fields[0];
            this.データ作成時刻 = fields[1];//
            this.法人コード = fields[2];//  2 39
            this.法人名漢字 = fields[3];//   20 41
            this.法人名カナ = fields[4];//  15 61
            this.店舗コード = fields[5];//  3 76

            this.店舗名漢字 = fields[6];//  20 79
            this.店舗名カナ = fields[7];//  15  99
            this.部門コード = fields[8];// 2   114
            this.部門名漢字 = fields[9];//  20  116
            this.部門名カナ = fields[10];//  15  136
            this.仕入先コード = fields[11];// 6   151
            this.仕入先名漢字 = fields[12];// 20  157
            this.仕入先名カナ = fields[13];// 15  177
            this.支払仕入先コード = fields[14];//   6   192
            this.支払仕入先名漢字 = fields[15];//   20  198
            this.支払仕入先名カナ = fields[16];//   15  218
            this.出荷業務仕入先コード = fields[17];// 6   233
            this.伝票区分 = fields[18];//   2   239
            this.赤黒区分 = fields[19];//   1   241

            this.伝票番号 = fields[20];//   8   242
            this.行番号 = fields[21];//   2   250
            this.元伝票番号 = fields[22];//  8   252
            this.発生日 = fields[23];//        8   260
            this.仕入計上日 = fields[24];//  8   268
            this.商品コード区分 = fields[25];//   1   276
            this.ＪＡＮコード = fields[26];//     13  277
            this.商品コード = fields[27];//    8   290
            this.オプション使用欄 = fields[28];//   20  298
            this.ＧＴＩＮ = fields[29];//       14  318
            this.品名漢字 = fields[30];//       20  332
            this.品名カナ = fields[31];//      25  352
            this.規格名漢字 = fields[32];//      20  377
            this.規格名カナ = fields[33];//      25  397
            this.数量 = fields[34];//            6   422
            this.総額取引区分 = fields[35];//    1   428

            this.原単価_税抜_ = fields[36];//   9   429
            this.原単価_税込_ = fields[37];//   9   438
            this.原価金額_税抜_ = fields[38];//  9   447
            this.原価金額_税込_ = fields[39];//  9   456
            this.税区分 = fields[40];//      1   465
            this.税率 = fields[41];//         4   466
            this.税額 = fields[42];//        9   470
            this.売単価_税抜_ = fields[43];//  7   479
            this.売単価_税込_ = fields[44];//  7   486
            this.特価区分 = fields[45];//        1   493
            this.PB区分 = fields[46];//       1 494
            this.原価区分 = fields[47];//       1   495
            this.受領区分 = fields[48];//       2   496
            this.理由区分 = fields[49];//       2   498
            this.理由コード = fields[50];//      2   500
            this.理由漢字 = fields[51];//       20  502
            this.連絡事項１ = fields[52];//      30  522
            this.連絡事項２ = fields[53];//      30  552
            this.納品先店舗コード = fields[54];//   3   582

            this.納品先店舗名漢字 = fields[55];//   20  585
            this.納品先店舗名カナ = fields[56];//   15  605
            this.センター経由区分 = fields[57];//   1   620
            this.センターコード = fields[58];//   5   621
            this.センター名漢字 = fields[59];//    20  626

        }

        public v_receivedorder ConverToEntity(GODDbContext ctx )
        {
            this.entity = FindMatchedOrder(ctx);

            if (entity != null)
            {

            }

            return entity;
        }


        public CustomMySqlParameters ToSqlArguments()
        {
            //52 受領区分       2   496
            //53 理由区分       2   498
            //54 理由コード      2   500
            //55 理由漢字       20  502
            //56 連絡事項１      30  522
            //57 連絡事項２      30  552

            var o = this.entity;
            string sql = @"UPDATE  `t_orderdata` SET
`受領確認`= 1, `受領数量`= @p1 
WHERE id受注データ= @P0;";

            MySqlParameter[] parameters = { new MySqlParameter("@p1", this.ReceivedQuantity), new MySqlParameter("@p0", this.entity.id受注データ) };

            return new CustomMySqlParameters(parameters, sql);
        }

        public string ToRawSql() {

            var o = this.entity;
            string format = @"UPDATE  `t_orderdata` SET `受領確認`= 1, `受領数量`= {2}, `Status`={3} WHERE `Status`={4} and `伝票番号`= {0} and `店舗コード`={1};";

            return String.Format(format, this.InvoiceCode, this.StoreCode, this.ReceivedQuantity, (int)OrderStatus.Received, (int)OrderStatus.ASN);
        
        }

        public int InvoiceCode {
            get { return Convert.ToInt32(this.伝票番号);  }
        }

        public int StoreCode
        {
            get { return Convert.ToInt32(this.店舗コード); }
        }
        public string StoreName
        {
            get { return this.店舗名漢字; }
        }
        public int ReceivedQuantity {
            get { return Convert.ToInt32(this.数量); }
        }


        private v_receivedorder FindMatchedOrder(GODDbContext ctx)
        {
            var date = DateTime.Now.AddMonths(-3);
            var order = (from t_orderdata o in ctx.t_orderdata
                         where o.店舗コード == StoreCode && o.伝票番号 == InvoiceCode && o.受注日 > date && o.受領確認 == false
                         select( new v_receivedorder { id受注データ=o.id受注データ, 店舗コード=o.店舗コード, 伝票番号= o.伝票番号 })).FirstOrDefault();
            return order;
        }


    }
}
