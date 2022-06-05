using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.Models
{
    public class ArticlesViewModel
    {
        public List<Article> articles { get; set; }
        public Article  Article { get; set; }

        public List<string> departments = new List<string>(new string[] { "Basın Yayın ve Halkla İlişkiler Dairesi Başkanlığı", "Bilgi İşlem Dairesi Başkanlığı", "Çevre Koruma ve Kontrol Dairesi Başkanlığı"
       , "Deprem Risk Yönetimi ve Kentsel İyileştirme Dairesi Başkanlığı", "Destek Hizmetleri Dairesi Başkanlığı", "Emlak ve İstimlak Dairesi Başkanlığı", "Fen İşleri Dairesi Başkanlığı",
       "Hukuk Müşavirliği", "İmar ve Şehircilik Dairesi Başkanlığı", "İnsan Kaynakları ve Eğitim Dairesi Başkanlığı", "İşletme ve İştirakler Dairesi Başkanlığı", "Kent Estetiği Dairesi Başkanlığı",
            "Kırsal Hizmetler Dairesi Başkanlığı", "Kültür ve Sosyal İşler Dairesi Başkanlığı", "Kültür ve Tabiat Varlıkları Dairesi Başkanlığı", "Makine İkmal Bakım ve Onarım Dairesi Başkanlığı", "Mali Hizmetler Dairesi Başkanlığı"
        , "element3", "element3", "element3", "İtfaiye Dairesi Başkanlığı", "Mezarlıklar Dairesi Başkanlığı", "Özel Projeler ve Dönüşüm Dairesi Başkanlığı", "Sağlık İşleri Dairesi Başkanlığı", "Sosyal Hizmetler Dairesi Başkanlığı",
            "Teftiş Kurulu Başkanlığı", "Ulaşım Dairesi Başkanlığı", "Yapı Kontrol Dairesi Başkanlığı","Yazı İşleri ve Kararlar Dairesi Başkanlığı","Zabıta Dairesi Başkanlığı"

       });

        
    }
}
