using Sitecore.Data.Items;
using Sitecore.Links.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Buckets.Managers;
using Sitecore.Buckets.Extensions;
using Sitecore.IO;

namespace Capgemini.Demo.Project.Custom
{
    public class CustomItemUrlBuilder : ItemUrlBuilder
    {
        public CustomItemUrlBuilder(DefaultItemUrlBuilderOptions option):base(option)
        {

        }
        //original to custom link (strip of bucket items)
        public override string Build(Item item, ItemUrlBuilderOptions options)
        {
            //Books/2021/06/10/17/00/Blink to Books/Blink

            if (BucketManager.IsItemContainedWithinBucket(item)) // If "Blink" book is the item here or not
            {
                var bucketItem = item.GetParentBucketItemOrParent();
                if (bucketItem != null && bucketItem.IsABucket())//books item
                {
                    //http://capgeminidemo.local/en/Books
                    var bucketUrl = base.Build(bucketItem, options);

                    //http://capgeminidemo.local/en/Books/Blink
                    return FileUtil.MakePath(bucketUrl, item.Name.Replace(' ', '-'));
                }
            }
            return base.Build(item, options);
        }
    }
}