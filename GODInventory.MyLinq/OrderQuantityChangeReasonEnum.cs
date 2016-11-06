using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GODInventory.MyLinq
{
    // 00- 訂正なし（完納）
    // 01- 発注変更（お取引先様出荷作業前の発注数変更）
    // 02- 該当商品なし（コードエラー、パッケージ変更、扱いなしなど）
    // 03- 製造中止
    // 04- 品切れ
    // 05- 契約違い（原価違いなど）
    // 06- 発売前（新製品未入荷）
    // 07- 帳合（仕入先）違い
    // 09- 発注単位違い
    // 99- その他
    public enum OrderQuantityChangeReasonEnum { 訂正なし = 0, 発注変更 = 1, 該当商品なし = 2, 製造中止 = 3, 品切れ = 4,
        契約違い = 5, 発売前 = 6, 帳合 = 7, 発注単位違い = 9, その他 = 99
    }
}
