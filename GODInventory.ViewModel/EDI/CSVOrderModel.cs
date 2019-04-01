using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GODInventory.ViewModel.EDI
{
    using GODInventory.MyLinq;
    using MySql.Data.MySqlClient;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    public class CSVOrderModel
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
        //11 店舗名カナ  15 99
        //12 仕入先コード 6 114
        //13 仕入先名漢字 20 120
        //14 仕入先名カナ 15 140
        //15 出荷業務仕入先コード 6 155
        //16 伝票区分   2 161
        //17 伝票番号   8 163
        //18 行番号    2 171
        //19 発注日    8 173
        //20 納品予定日  8 181
        //21 発注 データ有効期限 8 189
        //22 EDI発注区分    1 197
        //23 発注形態区分 2 198

        //24 発注形態名称漢字   6 200
        //25 予備  （数値  ） 2 206
        //26 本部発注区分 1 208
        //27 部門 コード 2 209
        //28 部門名漢字  20 211
        //29 部門名カナ  15 231
        //30 ラインコード 2 246
        //31 クラスコード 2 248
        //32 ロケーションコード  6 250
        //33 商品 コード区分   1 256
        //34 ＪＡＮコード     13 257
        //35 商品 コード     8 270
        //36 オプション使用欄   20 278
        //37 ＧＴＩＮ       14 298
        //38 品名漢字       20 312
        //39 品名 カナ      25 332
        //40 規格名漢字      20 357
        //41 規格名カナ  25 377

        //42 発注数        6 402
        //43 最小発注単位数量   6 408
        //44 発注単位名称漢字   8 414
        //45 発注単位名称カナ   4 422 
        //46 総額取引区分     1 426
        //47 原単価(税抜 )   9 427
        //48 原単価(税込 )   9 436
        //49 原価金額(税抜 )  9 445
        //50 原価金額(税込 )  9 454
        //51 税額             9 463
        //52 税区分        1 472
        //53 税率         4 473
        //54 売単価（税抜  ）  7 477
        //55 売単価（税込  ）  7 484
        //56 特価区分       1 491
        //57 PB区分       1 492
        //58 原価区分       1 493
        //59 用度品区分      1 494
        //60 納期回答区分     1 495
        //61 回答納期       8 496

        //62 色名 カナ      6 504
        //63 柄名 カナ      6 510
        //64 サイズ名カナ     5 516
        //65 広告 コード     8 521
        //66 伝票出力単位     3 529
        //67 納品先店舗コード   3 532
        //68 納品先店舗名漢字   20 535
        //69 納品先店舗名カナ   15 555
        //70 納品場所コード    1 570
        //71 納品場所名漢字    6 571
        //72 納品場所名カナ    6 577
        //73 便区分            6 583
        //74 センター経由区分   1 584
        //75 センターコード    5 585
        //76 センター名漢字    20 590
        //77 センター名カナ    15 610
        //78 予備             76 625
        string 受注日;
        string 受注時刻;
        string データID;   //1 データID       3 1
        string 管理連番;    //2 管理連番        13 4
        string システム管理日付;    //3 システム管理日付 8 17
        string データ作成日; //4 データ作成日      8 25
        string データ作成時刻; //5 データ作成時刻 6 33
        string 法人コード; //6 法人コード  2 39
        string 法人名漢字; //7 法人名漢字   20 41
        string 法人名カナ; //8 法人名カナ  15 61
        string 店舗コード; //9 店舗コード  3 76
        string 店舗名漢字; //10 店舗名漢字  20 79
        string 店舗名カナ; //11 店舗名カナ  15 99
        string 仕入先コード; //12 仕入先コード 6 114
        string 仕入先名漢字; //13 仕入先名漢字 20 120
        string 仕入先名カナ; //14 仕入先名カナ 15 140
        string 出荷業務仕入先コード; //15 出荷業務仕入先コード 6 155
        string 伝票区分; //16 伝票区分   2 161
        string 伝票番号; //17 伝票番号   8 163
        string 行番号; //18 行番号    2 171
        string 発注日; //19 発注日    8 173
        string 納品予定日; //20 納品予定日  8 181
        string 発注データ有効期限; //21 発注データ有効期限 8 189
        string EDI発注区分; //22 EDI発注区分    1 197
        string 発注形態区分; //23 発注形態区分 2 198

        string 発注形態名称漢字; //24 発注形態名称漢字   6 200
        string 予備_数値_; //25 予備  （数値  ） 2 206
        string 本部発注区分; //26 本部発注区分 1 208
        string 部門コード; //27 部門コード 2 209
        string 部門名漢字; //28 部門名漢字  20 211
        string 部門名カナ; //29 部門名カナ  15 231
        string ラインコード; //30 ラインコード 2 246
        string クラスコード; //31 クラスコード 2 248
        string ロケーションコード; //32 ロケーションコード  6 250
        string 商品コード区分; //33 商品コード区分   1 256
        string ＪＡＮコード; //34 ＪＡＮコード     13 257
        string 商品コード; //35 商品コード     8 270
        string オプション使用欄; //36 オプション使用欄   20 278
        string ＧＴＩＮ; //37 ＧＴＩＮ       14 298
        string 品名漢字; //38 品名漢字       20 312
        string 品名カナ; //39 品名カナ      25 332
        string 規格名漢字; //40 規格名漢字      20 357
        string 規格名カナ; //41 規格名カナ  25 377

        string 発注数量; //42 発注数        6 402
        string 最小発注単位数量; //43 最小発注単位数量   6 408
        string 発注単位名称漢字; //44 発注単位名称漢字   8 414
        string 発注単位名称カナ; //45 発注単位名称カナ   4 422 
        string 総額取引区分; //46 総額取引区分     1 426
        string 原単価_税抜_; //47 原単価(税抜 )   9 427
        string 原単価_税込_; //48 原単価(税込 )   9 436
        string 原価金額_税抜_; //49 原価金額(税抜 )  9 445
        string 原価金額_税込_; //50 原価金額(税込 )  9 454
        string 税額; //51 税額             9 463
        string 税区分; //52 税区分        1 472
        string 税率; //53 税率         4 473
        string 売単価_税抜_; //54 売単価（税抜  ）  7 477
        string 売単価_税込_; //55 売単価（税込  ）  7 484
        string 特価区分; //56 特価区分       1 491
        string PB区分; //57 PB区分       1 492
        string 原価区分; //58 原価区分       1 493
        string 用度品区分; //59 用度品区分      1 494
        string 納期回答区分; //60 納期回答区分     1 495
        string 回答納期; //61 回答納期       8 496

        string 色名カナ; //62 色名カナ      6 504
        string 柄名カナ; //63 柄名カナ      6 510
        string サイズ名カナ; //64 サイズ名カナ     5 516
        string 広告コード; //65 広告コード     8 521
        string 伝票出力単位; //66 伝票出力単位     3 529
        string 納品先店舗コード; //67 納品先店舗コード   3 532
        string 納品先店舗名漢字; //68 納品先店舗名漢字   20 535
        string 納品先店舗名カナ; //69 納品先店舗名カナ   15 555
        string 納品場所コード; //70 納品場所コード    1 570
        string 納品場所名漢字; //71 納品場所名漢字    6 571
        string 納品場所名カナ; //72 納品場所名カナ    6 577
        string 便区分; //73 便区分            6 583
        string センター経由区分; //74 センター経由区分   1 584
        string センターコード; //75 センターコード    5 585
        string センター名漢字; //76 センター名漢字    20 590
        string センター名カナ; //77 センター名カナ    15 610
        string 予備; //78 予備             76 625
        
        string nr;

        public short StoreCode { get; set; }
        public long JanCode { get; set; }
        public short 入力区分 { get; set; }
        // 订单是否存在，检测导入重复订单
        public bool IsExist { get; set; }

        public string StoreName {
            get { return this.店舗名漢字; }
        }
        public string LocationName
        {
            get { return this.納品場所名漢字; }
        }
        public int OrderCode
        {
            get { return Convert.ToInt32(this.伝票番号);  }
        }

        public bool IsByFax
        {
            get { return Head.IsByFax(); }
        }

        //FAX订单都是5位或者6位的, 小于1000000的传票番号都是FAX订单
        public bool IsValid 
        {
            get { return IsByFax ? OrderCode < 1000000 : true; } 
        }

        
        public CSVOrderHeadModel Head { get; set; }
        public CSVOrderModel(CSVOrderHeadModel head, string line)
        {
            Head = head;
            string utf8Line = EncodingUtility.ConvertShiftJisStringToUtf8(line);

            var untrimFields = utf8Line.Split(',');
            var fields = untrimFields.Select(s => s.Trim('"')).ToList();
            Debug.Assert( fields.Count() == 17 || fields.Count() == 74); // fax/normal
            if (!IsByFax)
            {
                this.受注日 = fields[0]; //1 受注日 
                this.受注時刻 = fields[1]; //

                this.法人コード = fields[2]; //6 法人コード  2 39
                this.法人名漢字 = fields[3]; //7 法人名漢字   20 41
                this.法人名カナ = fields[4]; //8 法人名カナ  15 61
                this.店舗コード = fields[5]; //9 店舗コード  3 76
                this.店舗名漢字 = fields[6]; //10 店舗名漢字  20 79
                this.店舗名カナ = fields[7]; //11 店舗名カナ  15 99
                this.仕入先コード = fields[8]; //12 仕入先コード 6 114
                this.仕入先名漢字 = fields[9]; //13 仕入先名漢字 20 120
                this.仕入先名カナ = fields[10]; //14 仕入先名カナ 15 140
                this.出荷業務仕入先コード = fields[11]; //15 出荷業務仕入先コード 6 155
                this.伝票区分 = fields[12]; //16 伝票区分   2 161
                this.伝票番号 = fields[13]; //17 伝票番号   8 163
                this.行番号 = fields[14]; //18 行番号    2 171

                this.発注日 = fields[15]; //15 発注日               
                this.納品予定日 = fields[16]; //20 納品予定日  8 181
                this.発注データ有効期限 = fields[17]; //21 発注データ有効期限 8 189
                this.EDI発注区分 = fields[18]; //22 EDI発注区分    1 197
                this.発注形態区分 = fields[19]; //23 発注形態区分 2 198

                this.発注形態名称漢字 = fields[20]; //24 発注形態名称漢字   6 200
                //this.予備数値 = fields[21]; //25 予備  （数値  ） 2 206
                this.本部発注区分 = fields[22]; //26 本部発注区分 1 208
                this.部門コード = fields[23]; //27 部門コード 2 209
                this.部門名漢字 = fields[24]; //28 部門名漢字  20 211
                this.部門名カナ = fields[25]; //29 部門名カナ  15 231
                this.ラインコード = fields[26]; //30 ラインコード 2 246
                this.クラスコード = fields[27]; //31 クラスコード 2 248
                this.ロケーションコード = fields[28]; //32 ロケーションコード  6 250
                this.商品コード区分 = fields[29]; //33 商品コード区分   1 256
                this.ＪＡＮコード = fields[30]; //34 ＪＡＮコード     13 257
                this.商品コード = fields[31]; //35 商品コード     8 270
                this.オプション使用欄 = fields[32]; //36 オプション使用欄   20 278
                this.ＧＴＩＮ = fields[33]; //37 ＧＴＩＮ       14 298
                this.品名漢字 = fields[34]; //38 品名漢字       20 312
                this.品名カナ = fields[35]; //39 品名カナ      25 332
                this.規格名漢字 = fields[36]; //40 規格名漢字      20 357
                this.規格名カナ = fields[37]; //41 規格名カナ  25 377

                this.発注数量 = fields[38]; //42 発注数        6 402
                this.最小発注単位数量 = fields[39]; //43 最小発注単位数量   6 408
                this.発注単位名称漢字 = fields[40]; //44 発注単位名称漢字   8 414
                this.発注単位名称カナ = fields[41]; //45 発注単位名称カナ   4 422 
                this.総額取引区分 = fields[42]; //46 総額取引区分     1 426
                this.原単価_税抜_ = fields[43]; //47 原単価(税抜 )   9 427
                this.原単価_税込_ = fields[44]; //48 原単価(税込 )   9 436
                this.原価金額_税抜_ = fields[45]; //49 原価金額(税抜 )  9 445
                this.原価金額_税込_ = fields[46]; //50 原価金額(税込 )  9 454
                this.税額 = fields[47]; //51 税額             9 463
                this.税区分 = fields[48]; //52 税区分        1 472
                this.税率 = fields[49]; //53 税率         4 473
                this.売単価_税抜_ = fields[50]; //54 売単価（税抜  ）  7 477
                this.売単価_税込_ = fields[51]; //55 売単価（税込  ）  7 484
                this.特価区分 = fields[52]; //56 特価区分       1 491
                this.PB区分 = fields[53]; //57 PB区分       1 492
                this.原価区分 = fields[54]; //58 原価区分       1 493
                this.用度品区分 = fields[55]; //59 用度品区分      1 494
                this.納期回答区分 = fields[56]; //60 納期回答区分     1 495
                this.回答納期 = fields[57]; //61 回答納期       8 496

                this.色名カナ = fields[58]; //62 色名カナ      6 504
                this.柄名カナ = fields[59]; //63 柄名カナ      6 510
                this.サイズ名カナ = fields[60]; //64 サイズ名カナ     5 516
                this.広告コード = fields[61]; //65 広告コード     8 521
                this.伝票出力単位 = fields[62]; //66 伝票出力単位     3 529
                this.納品先店舗コード = fields[63]; //67 納品先店舗コード   3 532
                this.納品先店舗名漢字 = fields[64]; //68 納品先店舗名漢字   20 535
                this.納品先店舗名カナ = fields[65]; //69 納品先店舗名カナ   15 555
                this.納品場所コード = fields[66]; //70 納品場所コード    1 570
                this.納品場所名漢字 = fields[67]; //71 納品場所名漢字    6 571
                this.納品場所名カナ = fields[68]; //72 納品場所名カナ    6 577
                this.便区分 = fields[69]; //73 便区分            6 583
                this.センター経由区分 = fields[70]; //74 センター経由区分   1 584
                this.センターコード = fields[71]; //75 センターコード    5 585
                this.センター名漢字 = fields[72]; //76 センター名漢字    20 590
                this.センター名カナ = fields[73]; //77 センター名カナ    15 610
                this.入力区分 = 0; //EDI
                //this.予備 = fields[74]; //78 予備             76 625
            }  else 
            { 
                //店舗,納品場所,伝票番号,JANコード,商品コード,商品名,規格,発注原単価,発注売単価,発注数量,ASN出荷NO,ASN数量,受領原単価,受領売単価,受領数量,受領受信日,受領計上日
                this.店舗名漢字 = fields[0];
                this.納品場所名漢字 = fields[1];
                this.伝票番号 = fields[2];
                this.ＪＡＮコード = fields[3];
                this.商品コード = fields[4];
                this.品名漢字 = fields[5];
                this.規格名漢字 = fields[6];
                this.原単価_税抜_ = fields[7];
                this.売単価_税抜_ = fields[8];
                this.発注数量 = fields[9];
                this.入力区分 = 1; //FAX
            }
            
            this.StoreCode = Convert.ToInt16(this.店舗コード);
            this.JanCode = Convert.ToInt64(this.ＪＡＮコード);
            IsExist = false;
        }

        public t_orderdata ConverToEntity() {
            var now = DateTime.Now;
            var orderdata = new t_orderdata();

            orderdata.受注日 = DateTime.ParseExact(this.受注日, "yyyyMMdd", CultureInfo.InvariantCulture);
            int i = Convert.ToInt32(this.受注時刻);
            orderdata.受注時刻 = new TimeSpan( i/10000, (i%10000)/100, i%100);

                orderdata.法人コード = Convert.ToInt16(this.法人コード);
                orderdata.法人名漢字 = this.法人名漢字.Trim();
                orderdata.法人名カナ = this.法人名カナ.Trim();

                orderdata.店舗コード = Convert.ToInt16(this.店舗コード);
                orderdata.店舗名漢字 = this.店舗名漢字.Trim();
                orderdata.店舗名カナ = this.店舗名カナ.Trim();

                orderdata.仕入先コード = Convert.ToInt32(this.仕入先コード);
                orderdata.仕入先名漢字 = this.仕入先名漢字.Trim();
                orderdata.仕入先名カナ = this.仕入先名カナ.Trim();
                orderdata.出荷業務仕入先コード = Convert.ToInt32(this.出荷業務仕入先コード);
                orderdata.伝票区分 = Convert.ToInt16(this.伝票区分);

                orderdata.伝票番号 = Convert.ToInt32( this.伝票番号);
                orderdata.行番号 = Convert.ToInt16(this.行番号);
                orderdata.発注日 = DateTime.ParseExact( this.発注日, "yyyyMMdd", CultureInfo.InvariantCulture);
                orderdata.納品予定日 = DateTime.ParseExact(this.納品予定日, "yyyyMMdd", CultureInfo.InvariantCulture);
                orderdata.発注データ有効期限 = DateTime.ParseExact(this.発注データ有効期限, "yyyyMMdd", CultureInfo.InvariantCulture);
                orderdata.EDI発注区分 = Convert.ToInt16(this.EDI発注区分);
                orderdata.発注形態区分 = Convert.ToInt16(this.発注形態区分);

                orderdata.発注形態名称漢字 = this.発注形態名称漢字.Trim();
                orderdata.予備_数値_ = Convert.ToInt32(this.予備_数値_);
                orderdata.本部発注区分 = Convert.ToInt16(this.本部発注区分);
                orderdata.部門コード = Convert.ToInt16(this.部門コード);
                orderdata.部門名漢字 = this.部門名漢字.Trim();
                orderdata.部門名カナ = this.部門名カナ.Trim();
                orderdata.ラインコード = Convert.ToInt32(this.ラインコード);
                orderdata.クラスコード = Convert.ToInt32(this.クラスコード);
                orderdata.ロケーションコード = Convert.ToInt32(this.ロケーションコード);
                orderdata.商品コード区分 = Convert.ToInt32(this.商品コード区分);
                orderdata.ＪＡＮコード = Convert.ToInt64(this.ＪＡＮコード);
                orderdata.商品コード = Convert.ToInt32(this.商品コード);
                orderdata.オプション使用欄 = this.オプション使用欄.Trim(); //36 オプション使用欄   20 278
                orderdata.ＧＴＩＮ = ""; //37 ＧＴＩＮ       14 298
                orderdata.品名漢字 = this.品名漢字.Trim();
                orderdata.品名カナ = this.品名カナ.Trim();
                orderdata.規格名漢字 = this.規格名漢字.Trim();
                orderdata.規格名カナ = this.規格名カナ.Trim();


                orderdata.発注数量 = Convert.ToInt32(this.発注数量);

                orderdata.最小発注単位数量 = Convert.ToInt32(this.最小発注単位数量);
                orderdata.発注単位名称漢字 = this.発注単位名称漢字.Trim();
                orderdata.発注単位名称カナ = this.発注単位名称カナ.Trim();
                orderdata.総額取引区分 = Convert.ToInt16(this.総額取引区分);
                // tbd...
                orderdata.原単価_税抜_ = Convert.ToInt32(this.原単価_税抜_);
                orderdata.原単価_税込_ = Convert.ToDouble(this.原単価_税込_); //48 原単価(税込 )   9 436
                orderdata.原価金額_税抜_ = orderdata.原単価_税抜_ * orderdata.発注数量; // 兼容 FAX订单，FAX订单没有 原価金額_税抜_  
                //Convert.ToInt32(this.原価金額_税抜_);
                orderdata.原価金額_税込_ = Convert.ToInt32(this.原価金額_税込_);

                orderdata.税額 = Convert.ToDouble(this.税額);
                orderdata.税区分 = Convert.ToInt16(this.税区分); 
                orderdata.税率 = Convert.ToDouble(this.税率);

                orderdata.売単価_税抜_ = Convert.ToInt32(this.売単価_税抜_);
                orderdata.売単価_税込_ = Convert.ToInt32(this.売単価_税込_);
                orderdata.特価区分 = Convert.ToInt16(this.特価区分);
                orderdata.PB区分 = Convert.ToInt16(this.PB区分);
                orderdata.原価区分 = Convert.ToInt16(this.原価区分);
                orderdata.用度品区分 = Convert.ToInt16(this.用度品区分);
                orderdata.納期回答区分 = Convert.ToInt16(this.納期回答区分);
                orderdata.回答納期 = "00000000";

                orderdata.色名カナ = this.色名カナ.Trim();
                orderdata.柄名カナ = this.柄名カナ.Trim();
                orderdata.サイズ名カナ = this.サイズ名カナ.Trim();
                orderdata.広告コード = Convert.ToInt32(this.広告コード);
                orderdata.伝票出力単位 = Convert.ToInt16(this.伝票出力単位);
                orderdata.納品先店舗コード = Convert.ToInt16(this.納品先店舗コード);
                orderdata.納品先店舗名漢字 = this.納品先店舗名漢字.Trim();
                orderdata.納品先店舗名カナ = this.納品先店舗名カナ.Trim();
                orderdata.納品場所コード = (this.納品場所コード.Trim().Length > 0 ? Convert.ToInt16(this.納品場所コード) : (short)0);
                orderdata.納品場所名漢字 = this.納品場所名漢字.Trim();
                orderdata.納品場所名カナ = this.納品場所名カナ.Trim();
                orderdata.便区分 = Convert.ToInt16(this.便区分);
                orderdata.センター経由区分 = Convert.ToInt16(this.センター経由区分);
                orderdata.センターコード = Convert.ToInt32(this.センターコード);
                orderdata.センター名漢字 = this.センター名漢字.Trim();
                orderdata.センター名カナ = this.センター名カナ.Trim();
            

            return orderdata;

        }
        public t_orderdata ConverToEntity(t_shoplist shop, t_itemlist item, v_itemprice price, t_locations location, List<t_orderdata> orders)
        {
            if (IsByFax)
            {
                this.受注日 = DateTime.Now.ToString("yyyyMMdd");
                this.受注日 = DateTime.Now.ToString("yyyyMMdd");
                this.店舗コード = shop.店番.ToString();
                this.店舗名カナ = shop.店名カナ;
                this.発注日 = DateTime.Now.ToString("yyyyMMdd");

                this.納品予定日 =  DateTime.Now.ToString("yyyyMMdd");
                this.発注データ有効期限 = DateTime.Now.ToString("yyyyMMdd");

                if (location != null)
                {
                    this.納品場所コード = location.納品場所コード.ToString();
                    this.納品場所名カナ = location.納品場所名カナ.ToString();
                }
                else {
                    this.納品場所コード = "0";
                    this.納品場所名カナ = "";
                }

                this.法人コード = "4";
                this.法人名漢字 = "Ｋナフコ";
                this.法人名カナ = "ｶ) ﾅﾌｺ";

                this.仕入先コード = "249706";
                this.仕入先名漢字 = "㈱ジー・オー・ディ";
                this.仕入先名カナ = "K.K.ｼﾞｰ･ｵｰ･ﾃﾞｨ";
                this.発注形態名称漢字 = "FAX";
                this.出荷業務仕入先コード = "249706";

                this.部門コード = "9";
                this.部門名漢字 = "エクステリア";
                this.部門名カナ = "ｴｸｽﾃﾘｱ";

                this.品名カナ = "";
                this.規格名カナ = "";
                this.オプション使用欄 = "";
                this.色名カナ = "";
                this.柄名カナ = "";

                this.センター名漢字 = "";
                this.センター名カナ = "";

                this.発注単位名称漢字 = "";
                this.発注単位名称カナ = "";
				this.サイズ名カナ = "";
                this.納品先店舗名漢字 = "";
                this.納品先店舗名カナ = "";
            }

            var orderdata = ConverToEntity();
            
            //orderdata.ダブリ = exist ? "yes" : "no";

            //有些为空的，订单重量 设置为0
            orderdata.ジャンル = item.ジャンル;
            orderdata.単位 = item.単位;
            orderdata.自社コード = item.自社コード;
            orderdata.実際配送担当 = price.配送担当;
            orderdata.最小発注単位数量 = item.PT入数;
            orderdata.重量 = (int)((item.単品重量 != null ? item.単品重量 : 0) * orderdata.発注数量);
            orderdata.口数 = orderdata.発注数量 / orderdata.最小発注単位数量;

            if (orderdata.発注数量 % orderdata.最小発注単位数量 != 0)
            {
                orderdata.口数++;
            }
            orderdata.納品口数 = orderdata.口数;
            orderdata.実際出荷数量 = orderdata.発注数量;
            orderdata.県別 = shop.県別;
            orderdata.warehousename = shop.warehousename;

            orderdata.社内伝番処理 = OrderSqlHelper.IsInnerCodeRequired(orderdata.ジャンル);
            //if (orderdata.実際配送担当 == "MKL" && (orderdata.ジャンル == 1001 || orderdata.ジャンル == 1003))
            //{
            //    orderdata.実際配送担当 = "丸健";
            //}
            if (orderdata.実際配送担当 == null || orderdata.実際配送担当 == String.Empty) {
                orderdata.実際配送担当 = shop.配送担当;
            }

            orderdata.納品原価金額 = orderdata.原価金額_税抜_;
            orderdata.発注品名漢字 = orderdata.品名漢字;
            orderdata.発注規格名漢字 = orderdata.規格名漢字;

            orderdata.仕入原価 = price.仕入原価;
            orderdata.仕入金額 = orderdata.実際出荷数量 * price.仕入原価;
            orderdata.粗利金額 = orderdata.納品原価金額 - orderdata.仕入金額;

            orderdata.id = String.Format("{0}a{1}", orderdata.店舗コード, orderdata.伝票番号);
            orderdata.週目 = OrderHelper.GetOrderWeekOfYear(orderdata.受注日.Value);

            orderdata.運賃 = OrderSqlHelper.ComputeFreight(orderdata, price.fee, price.columnname);

            if (orders != null)
            {
                bool existed = orders.Exists(o => (o.伝票番号 == orderdata.伝票番号 && o.店舗コード == orderdata.店舗コード));
                if (existed)
                {
                    orderdata.Status = OrderStatus.Existed;
                }
            }
            return orderdata;
        }

        public CustomMySqlParameters ToSqlArguments(t_shoplist shop, t_itemlist item, v_itemprice price, t_locations location, List<t_orderdata> orders)
        {
            //`発注日`, `受注日`, `出荷日`, `納品日`, `店舗コード`, `店舗名漢字`, `社内伝番`, `行数`, `最大行数`, `伝票番号`, `ダブリ`, 
            //`在庫状態`, `キャンセル`, `キャンセル時刻`, `ジャンル`, `ＪＡＮコード`, `商品コード`, `品名漢字`, `規格名漢字`, `発注数量`, 
            //`実際出荷数量`, `口数`, `納品口数`, `重量`, `単位`, `原単価(税抜)`, `原価金額(税抜)`, `納品原価金額`, `売単価（税抜）`, `一旦保留`, 
            //`実際配送担当`, `配送担当受信`, `配送担当受信時刻`, `専務受信`, `専務受信時刻`, `納品指示`, `納品場所コード`, `納品場所名漢字`, 
            //`受領`, `備考`, `週目`, `受領確認`, `受領数量`, `受領金額`, `受領差異数量`, `受領差異金額`, `受注時刻`, `法人コード`, 
            //`法人名漢字`, `法人名カナ`, `店舗名カナ`, `仕入先コード`, `仕入先名漢字`, `仕入先名カナ`, `出荷業務仕入先コード`, 
            //`伝票区分`, `行番号`, `納品予定日`, `発注データ有効期限`, `EDI発注区分`, `発注形態区分`, `発注形態名称漢字`, 
            //`予備（数値）`, `本部発注区分`, `部門コード`, `部門名漢字`, `部門名カナ`, `ラインコード`, `クラスコード`, `商品コード区分`, 
            //`ロケーションコード`, `オプション使用欄`, `ＧＴＩＮ`, `品名カナ`, `規格名カナ`, `最小発注単位数量`, `発注単位名称漢字`, 
            //`発注単位名称カナ`, `総額取引区分`, `原単価(税込)`, `原価金額(税込)`, `税額`, `税区分`, `税率`, `売単価（税込）`, `特価区分`, 
            //`PB区分`, `原価区分`, `用度品区分`, `納期回答区分`, `回答納期`, `色名カナ`, `柄名カナ`, `サイズ名カナ`, `広告コード`, `伝票出力単位`, 
            //`納品先店舗コード`, `納品先店舗名漢字`, `納品先店舗名カナ`, `納品場所名カナ`, `便区分`, `センター経由区分`, `センターコード`, 
            //`センター名漢字`, `センター名カナ
/*
            !受注時刻 = tTimeJ
                    !法人コード = Cells(i, 3).Value
                    !法人名漢字 = Cells(i, 4).Value
                    !法人名カナ = Cells(i, 5).Value
                    !店舗コード = Cells(i, 6).Value
                    !店舗名漢字 = Cells(i, 7).Value
                    !店舗名カナ = Cells(i, 8).Value
                    !仕入先コード = Cells(i, 9).Value
                    !仕入先名漢字 = Cells(i, 10).Value
                    !仕入先名カナ = Cells(i, 11).Value
                    !出荷業務仕入先コード = Cells(i, 12).Value
                    !伝票区分 = Cells(i, 13).Value
                    !伝票番号 = Cells(i, 14).Value
                    !行番号 = Cells(i, 15).Value
                    tDateS = Left(Cells(i, 16).Value, 4) & "/" & Mid(Cells(i, 16).Value, 5, 2) & "/" & Right(Cells(i, 16).Value, 2)
                    !発注日 = CDate(tDateS)
                    tDateS = Left(Cells(i, 17).Value, 4) & "/" & Mid(Cells(i, 17).Value, 5, 2) & "/" & Right(Cells(i, 17).Value, 2)
                    !納品予定日 = CDate(tDateS)
                    tDateS = Left(Cells(i, 18).Value, 4) & "/" & Mid(Cells(i, 18).Value, 5, 2) & "/" & Right(Cells(i, 18).Value, 2)
                    !発注データ有効期限 = CDate(tDateS)
                    !EDI発注区分 = Cells(i, 19).Value
                    !発注形態区分 = Cells(i, 20).Value
                    !発注形態名称漢字 = Cells(i, 21).Value
                    ![予備(数値)] = Cells(i, 22).Value
                    !本部発注区分 = Cells(i, 23).Value
                    !部門コード = Cells(i, 24).Value
                    !部門名漢字 = Cells(i, 25).Value
                    !部門名カナ = Cells(i, 26).Value
                    !ラインコード = Cells(i, 27).Value
                    !クラスコード = Cells(i, 28).Value
                    !ロケーションコード = Cells(i, 29).Value
                    !商品コード区分 = Cells(i, 30).Value
                    !JANコード = Cells(i, 31).Value
                    !商品コード = Cells(i, 32).Value
                    !オプション使用欄 = Cells(i, 33).Value
                    !GTIN = Cells(i, 34).Value
                    !品名漢字 = Cells(i, 35).Value
                    !品名カナ = Cells(i, 36).Value
                    !規格名漢字 = Cells(i, 37).Value
                    !規格名カナ = Cells(i, 38).Value
                    !発注数量 = Cells(i, 39).Value
                    !最小発注単位数量 = Cells(i, 40).Value
                    !発注単位名称漢字 = Cells(i, 41).Value
                    !発注単位名称カナ = Cells(i, 42).Value
                    !総額取引区分 = Cells(i, 43).Value
                    ![原単価(税抜)] = Cells(i, 44).Value
                    ![原単価(税込)] = Cells(i, 45).Value
                    ![原価金額(税抜)] = Cells(i, 46).Value
                    ![原価金額(税込)] = Cells(i, 47).Value
                    !税額 = Cells(i, 48).Value
                    !税区分 = Cells(i, 49).Value
                    !税率 = Cells(i, 50).Value
                    ![売単価(税抜)] = Cells(i, 51).Value
                    ![売単価(税込)] = Cells(i, 52).Value
                    !特価区分 = Cells(i, 53).Value
                    !PB区分 = Cells(i, 54).Value
                    !原価区分 = Cells(i, 55).Value
                    !用度品区分 = Cells(i, 56).Value
                    !納期回答区分 = Cells(i, 57).Value
                    !回答納期 = Cells(i, 58).Value
                    !色名カナ = Cells(i, 59).Value
                    !柄名カナ = Cells(i, 60).Value
                    !サイズ名カナ = Cells(i, 61).Value
                    !広告コード = Cells(i, 62).Value
                    !伝票出力単位 = Cells(i, 63).Value
                    !納品先店舗コード = Cells(i, 64).Value
                    !納品先店舗名漢字 = Cells(i, 65).Value
                    !納品先店舗名カナ = Cells(i, 66).Value
                    !納品場所コード = Cells(i, 67).Value
                    !納品場所名漢字 = Cells(i, 68).Value
                    !納品場所名カナ = Cells(i, 69).Value
                    !便区分 = Cells(i, 70).Value
                    !センター経由区分 = Cells(i, 71).Value
                    !センターコード = Cells(i, 72).Value
                    !センター名漢字 = Cells(i, 73).Value
                    !センター名カナ = Cells(i, 74).Value
                    */
            t_orderdata o = ConverToEntity(shop, item, price, location, orders);
            string sql = @"INSERT INTO `t_orderdata`(
`発注日`, `受注日`, `受注時刻`,  `店舗コード`, `店舗名漢字`, 
`伝票番号`, `ＪＡＮコード`, `商品コード`, `品名漢字`, `規格名漢字`, 
`発注数量`, `原単価(税抜)`, `原価金額(税抜)`, `納品原価金額`, `売単価（税抜）`,
`納品場所コード`, `納品場所名漢字`, `法人コード`, `法人名漢字`,`法人名カナ`,
`店舗名カナ`, `仕入先コード`, `仕入先名漢字`, `仕入先名カナ`, `出荷業務仕入先コード`, 
`伝票区分`, `行番号`, `納品予定日`, `発注データ有効期限`, `EDI発注区分`, 
`発注形態区分`, `発注形態名称漢字`, `予備（数値）`, `本部発注区分`, `部門コード`, 
`部門名漢字`, `部門名カナ`, `ラインコード`, `クラスコード`, `商品コード区分`, 
`ロケーションコード`, `オプション使用欄`, `ＧＴＩＮ`, `品名カナ`, `規格名カナ`, 
`最小発注単位数量`, `発注単位名称漢字`, `発注単位名称カナ`, `総額取引区分`, `原単価(税込)`, 
`原価金額(税込)`, `税額`, `税区分`, `税率`, `売単価（税込）`, 
`特価区分`, `PB区分`, `原価区分`, `用度品区分`, `納期回答区分`, 
`回答納期`, `色名カナ`, `柄名カナ`, `サイズ名カナ`, `広告コード`, 
`伝票出力単位`, `納品先店舗コード`, `納品先店舗名漢字`, `納品先店舗名カナ`, `納品場所名カナ`, 
`便区分`, `センター経由区分`, `センターコード`, `センター名漢字`, `センター名カナ`,
`実際配送担当`, `配送担当受信`,`口数`,`重量`,`単位`,
`ジャンル`) 
VALUES (
@p1, @p2, @p3, @p4, @p5, 
@p6, @p7, @p8, @p9, @p10, 
@p11, @p12, @p13, @p14, @p15, @p16, @p17, @p18, @p19, @p20, 
@p21, @p22, @p23, @p24, @p25, @p26, @p27, @p28, @p29, @p30, 
@p31, @p32, @p33, @p34, @p35, @p36, @p37, @p38, @p39, @p40, 
@p41, @p42, @p43, @p44, @p45, @p46, @p47, @p48, @p49, @p50, 
@p51, @p52, @p53, @p54, @p55, @p56, @p57, @p58, @p59, @p60, 
@p61, @p62, @p63, @p64, @p65, @p66, @p67, @p68, @p69, @p70, 
@p71, @p72, @p73, @p74, @p75, @p76, @p77, @p78, @p79, @p80,
@p81, @p82);";

            MySqlParameter[] parameters = { new MySqlParameter("@p1", o.発注日), new MySqlParameter("@p2", o.受注日), new MySqlParameter("@p3", o.受注時刻), new MySqlParameter("@p4", o.店舗コード), new MySqlParameter("@p5", o.店舗名漢字),
       new MySqlParameter("@p6", o.伝票番号), new MySqlParameter("@p7", o.ＪＡＮコード), new MySqlParameter("@p8", o.商品コード), new MySqlParameter("@p9", o.品名漢字),new MySqlParameter("@p10", o.規格名漢字),
       new MySqlParameter("@p11", o.発注数量), new MySqlParameter("@p12", o.原単価_税抜_), new MySqlParameter("@p13", o.原価金額_税抜_), new MySqlParameter("@p14", o.納品原価金額),new MySqlParameter("@p15", o.売単価_税抜_),
       new MySqlParameter("@p16", o.納品場所コード), new MySqlParameter("@p17", o.納品場所名漢字), new MySqlParameter("@p18", o.法人コード), new MySqlParameter("@p19", o.法人名漢字),new MySqlParameter("@p20", o.法人名カナ),
       new MySqlParameter("@p21", o.店舗名カナ), new MySqlParameter("@p22", o.仕入先コード), new MySqlParameter("@p23", o.仕入先名漢字), new MySqlParameter("@p24", o.仕入先名カナ),new MySqlParameter("@p25", o.出荷業務仕入先コード),
       new MySqlParameter("@p26", o.伝票区分), new MySqlParameter("@p27", o.行番号), new MySqlParameter("@p28", o.納品予定日), new MySqlParameter("@p29", o.発注データ有効期限),new MySqlParameter("@p30", o.EDI発注区分),
       new MySqlParameter("@p31", o.発注形態区分), new MySqlParameter("@p32", o.発注形態名称漢字), new MySqlParameter("@p33", o.予備_数値_), new MySqlParameter("@p34", o.本部発注区分),new MySqlParameter("@p35", o.部門コード),
       new MySqlParameter("@p36", o.部門名漢字), new MySqlParameter("@p37", o.部門名カナ), new MySqlParameter("@p38", o.ラインコード), new MySqlParameter("@p39", o.クラスコード),new MySqlParameter("@p40", o.商品コード区分),
       new MySqlParameter("@p41", o.ロケーションコード), new MySqlParameter("@p42", o.オプション使用欄), new MySqlParameter("@p43", o.ＧＴＩＮ), new MySqlParameter("@p44", o.品名カナ),new MySqlParameter("@p45", o.規格名カナ),
       new MySqlParameter("@p46", o.最小発注単位数量), new MySqlParameter("@p47", o.発注単位名称漢字), new MySqlParameter("@p48", o.発注単位名称カナ), new MySqlParameter("@p49", o.総額取引区分),new MySqlParameter("@p50", o.原単価_税込_),
       new MySqlParameter("@p51", o.原価金額_税込_), new MySqlParameter("@p52", o.税額), new MySqlParameter("@p53", o.税区分), new MySqlParameter("@p54", o.税率),new MySqlParameter("@p55", o.売単価_税込_),
       new MySqlParameter("@p56", o.特価区分), new MySqlParameter("@p57", o.PB区分), new MySqlParameter("@p58", o.原価区分), new MySqlParameter("@p59", o.用度品区分),new MySqlParameter("@p60", o.納期回答区分),
       new MySqlParameter("@p61", o.回答納期), new MySqlParameter("@p62", o.色名カナ), new MySqlParameter("@p63", o.柄名カナ), new MySqlParameter("@p64", o.サイズ名カナ),new MySqlParameter("@p65", o.広告コード),
       new MySqlParameter("@p66", o.伝票出力単位), new MySqlParameter("@p67", o.納品先店舗コード), new MySqlParameter("@p68", o.納品先店舗名漢字), new MySqlParameter("@p69", o.納品先店舗名カナ),new MySqlParameter("@p70", o.納品場所名カナ),
       new MySqlParameter("@p71", o.便区分), new MySqlParameter("@p72", o.センター経由区分), new MySqlParameter("@p73", o.センターコード), new MySqlParameter("@p74", o.センター名漢字),new MySqlParameter("@p75", o.センター名カナ),
       new MySqlParameter("@p76", o.実際配送担当),new MySqlParameter("@p77", o.配送担当受信),new MySqlParameter("@p78", o.口数),new MySqlParameter("@p79", o.重量),new MySqlParameter("@p80", o.単位),
       new MySqlParameter("@p81", o.ジャンル), new MySqlParameter("@p82", o.warehousename)     };

            return new CustomMySqlParameters(parameters, sql);

        }

        public string ToRawSql(t_shoplist shop, t_itemlist item, v_itemprice price, t_locations location, List<t_orderdata> orders)
        {
            var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
            t_orderdata o = ConverToEntity(shop, item, price, location, orders);
            if (o.Status == OrderStatus.Existed) 
            {
                //o.Status = OrderStatus.Pending;
                return null;
            }
            string format = @"INSERT INTO `t_orderdata`(
`発注日`, `受注日`, `受注時刻`,  `店舗コード`, `店舗名漢字`, 
`伝票番号`, `ＪＡＮコード`, `商品コード`, `品名漢字`, `規格名漢字`, 
`発注数量`, `原単価(税抜)`, `原価金額(税抜)`, `納品原価金額`, `売単価（税抜）`,
`納品場所コード`, `納品場所名漢字`, `法人コード`, `法人名漢字`,`法人名カナ`,
`店舗名カナ`, `仕入先コード`, `仕入先名漢字`, `仕入先名カナ`, `出荷業務仕入先コード`, 
`伝票区分`, `行番号`, `納品予定日`, `発注データ有効期限`, `EDI発注区分`, 
`発注形態区分`, `発注形態名称漢字`, `予備（数値）`, `本部発注区分`, `部門コード`, 
`部門名漢字`, `部門名カナ`, `ラインコード`, `クラスコード`, `商品コード区分`, 
`ロケーションコード`, `オプション使用欄`, `ＧＴＩＮ`, `品名カナ`, `規格名カナ`, 
`最小発注単位数量`, `発注単位名称漢字`, `発注単位名称カナ`, `総額取引区分`, `原単価(税込)`, 
`原価金額(税込)`, `税額`, `税区分`, `税率`, `売単価（税込）`, 
`特価区分`, `PB区分`, `原価区分`, `用度品区分`, `納期回答区分`, 
`回答納期`, `色名カナ`, `柄名カナ`, `サイズ名カナ`, `広告コード`, 
`伝票出力単位`, `納品先店舗コード`, `納品先店舗名漢字`, `納品先店舗名カナ`, `納品場所名カナ`, 
`便区分`, `センター経由区分`, `センターコード`, `センター名漢字`, `センター名カナ`,
`実際配送担当`, `配送担当受信`,`口数`,`重量`,`単位`,
`ジャンル`,`自社コード`,`実際出荷数量`,`県別`,`Status`,
`ダブリ`,`発注品名漢字`,`発注規格名漢字`,`納品口数`,`週目`,
`id`, `仕入原価`, `仕入金額`, `粗利金額`,`社内伝番処理`,
`warehousename`, `運賃`) 
VALUES ({0}
'{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}',{4},'{5}',
{6},{7},{8},'{9}','{10}',
{11},{12},{13},{14},{15},{16},'{17}',{18},'{19}','{20}',
'{21}',{22},'{23}','{24}',{25},{26},{27},'{28:yyyy-MM-dd}','{29:yyyy-MM-dd}',{30},
{31},'{32}',{33},{34},{35},'{36}','{37}',{38},{39},{40},
{41},'{42}','{43}','{44}','{45}',{46},'{47}','{48}',{49},{50},
{51},{52},{53},{54},{55},{56},{57},{58},{59},{60},
'{61}','{62}','{63}','{64}',{65},{66},{67},'{68}','{69}','{70}',
{71},{72},{73},'{74}','{75}','{76}',{77},{78},{79},'{80}',
{81},{82},{83},'{84}',{85},'{86}','{87}','{88}',{89},{90},
'{91}',{92},{93},{94},{95},'{96}',{97});"; 
            var now = DateTime.Now;
            var fazhuri = o.発注日.ToString(isoDateTimeFormat.UniversalSortableDateTimePattern);
            var souzhuri = now.ToString(isoDateTimeFormat.UniversalSortableDateTimePattern);
            var shouzhushike = now.ToString( "HH:mm:ss");
            var napinyudingri = ((DateTime)o.納品予定日).ToString(isoDateTimeFormat.UniversalSortableDateTimePattern);
            

            var qixian = DateTime.ParseExact(this.発注データ有効期限, "yyyyMMdd", CultureInfo.InvariantCulture).ToString(isoDateTimeFormat.UniversalSortableDateTimePattern);
            return String.Format(format, "", o.発注日, o.受注日, o.受注時刻, o.店舗コード, o.店舗名漢字,
                o.伝票番号, o.ＪＡＮコード, o.商品コード, o.品名漢字, o.規格名漢字, 
                o.発注数量, o.原単価_税抜_, o.原価金額_税抜_, o.納品原価金額, o.売単価_税抜_,
                o.納品場所コード, o.納品場所名漢字, o.法人コード, o.法人名漢字,o.法人名カナ,
                
                o.店舗名カナ, o.仕入先コード, o.仕入先名漢字, o.仕入先名カナ, o.出荷業務仕入先コード,
                o.伝票区分, o.行番号, o.納品予定日, o.発注データ有効期限, o.EDI発注区分, 
                o.発注形態区分, o.発注形態名称漢字, o.予備_数値_, o.本部発注区分, o.部門コード, 
                o.部門名漢字, o.部門名カナ, o.ラインコード, o.クラスコード, o.商品コード区分, 
                
                o.ロケーションコード, o.オプション使用欄, o.ＧＴＩＮ, o.品名カナ, o.規格名カナ, 
                o.最小発注単位数量, o.発注単位名称漢字, o.発注単位名称カナ, o.総額取引区分, o.原単価_税込_, 
                o.原価金額_税込_, o.税額, o.税区分, o.税率, o.売単価_税込_, 
                o.特価区分, o.PB区分, o.原価区分, o.用度品区分, o.納期回答区分, 
                
                o.回答納期, o.色名カナ, o.柄名カナ, o.サイズ名カナ, o.広告コード, 
                o.伝票出力単位, o.納品先店舗コード, o.納品先店舗名漢字, o.納品先店舗名カナ, o.納品場所名カナ, 
                o.便区分, o.センター経由区分, o.センターコード, o.センター名漢字, o.センター名カナ,
                o.実際配送担当, o.配送担当受信,o.口数,o.重量, o.単位,
                o.ジャンル, o.自社コード, o.実際出荷数量, o.県別, (int)o.Status, 
                o.ダブリ, o.発注品名漢字, o.発注規格名漢字, o.納品口数, o.週目,
                o.id, o.仕入原価, o.仕入金額, o.粗利金額, o.社内伝番処理,
                o.warehousename, o.運賃);
                
        }

        private string ConvertDateTimeToString(DateTime datetime) {
            return datetime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
