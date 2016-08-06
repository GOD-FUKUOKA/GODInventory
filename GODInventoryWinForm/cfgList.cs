using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventoryWinForm
{
    public class cfgList
    {
        private IDictionary inputmapping;


        public IDictionary Public_Name
        {
            get { return inputmapping; }
            set { inputmapping = value; }
        }


        private string 仕入先コード;
        public string _仕入先コード
        {
            get { return 仕入先コード; }
            set { 仕入先コード = value; }
        }
        private string 出荷業務仕入先コード;
        public string _出荷業務仕入先コード
        {
            get { return 出荷業務仕入先コード; }
            set { 出荷業務仕入先コード = value; }
        }
        private string 仕入先名カナ;
        public string _仕入先名カナ
        {
            get { return 仕入先コード; }
            set { 仕入先コード = value; }
        }

    }
}
