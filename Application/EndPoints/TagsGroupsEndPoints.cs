using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Client.EndPoints
{
    public class TagsGroupsEndPoints
    {
        public static string GetTagsLive => "/api/TagsLiveGroups/GetTagsLive";
        public static string GetTagsGroups => "/api/TagsLiveGroups/GetTagsGroups";
    }
}
