using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class EduacationBlogLibrariesServiceWrapper:IEduacationBlogLibrariesServiceWrapper
    {
        private List<EduacationBlogLibrary> eduacationBlogLibraryList = new List<EduacationBlogLibrary>
        {
            new EduacationBlogLibrary
            {
                Text =
                    "پذيرش اين نكته كه ممكن است در برنامه خود شكست بخوريد، يك امر كليدي است. در غير اين صورت، اگر شكست را به عنوان بخشي از زندگي نبينيد، كوچك ترين مشكلي كه ايجاد مي كند اين است كه «خويشتن» شما را متلاشي خواهد ساخت. خطر كنيد و ياد بگيريد كه گاهي بيافتيد. مسلما تلخي رد شدن در يك آزمون استخدامي مهم، وقتي كه در يك مصاحبه براي كار در يك شركت معمولي قبول مي شويد، شيرين تر مي شود.",
                Title = "اصل آمادگی برای پذيرش شكست "
            }
        };

        public void GetAllEduacationBlogLibrarList(Action<List<EduacationBlogLibrary>, Exception> action)
        {
            action(eduacationBlogLibraryList, null);
        }
    }
}
