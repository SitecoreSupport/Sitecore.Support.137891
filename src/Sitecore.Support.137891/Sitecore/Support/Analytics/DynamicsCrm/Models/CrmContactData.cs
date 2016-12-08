using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.DynamicsCrm.Models;

namespace Sitecore.Support.Analytics.DynamicsCrm.Models
{
    [Serializable]
    public class CrmContactData : Facet, ICrmContactData, IFacet, IElement, IValidatable
    {
        public CrmContactData()
        {
            base.EnsureAttribute<Guid>(nameof(ContactId));
            base.EnsureAttribute<string>(nameof(MarketingLists));
            base.EnsureAttribute<DateTime>(nameof(LastSynced));
            base.EnsureAttribute<string>(nameof(CrmName));
        }
        public Guid ContactId
        {
            get
            {
                return base.GetAttribute<Guid>(nameof(ContactId));
            }

            set
            {
                base.SetAttribute<Guid>(nameof(ContactId), value);
            }
        }
        public DateTime LastSynced
        {
            get
            {
                return base.GetAttribute<DateTime>(nameof(LastSynced));
            }

            set
            {
                base.SetAttribute<DateTime>(nameof(LastSynced), value);
            }
        }
        public ICollection<Guid> MarketingLists
        {
            get
            {
                var guids = new List<Guid>();
                var s = base.GetAttribute<string>(nameof(MarketingLists));
                if (s != null)
                {
                    var sGuids = s.Split(',').ToList();
                    foreach (var sGuid in sGuids)
                    {
                        var guid = Guid.Parse(sGuid);
                        guids.Add(guid);
                    }
                }
                return guids;
            }
            set
            {
                string s = null;
                if (value != null && value.Any())
                {
                    s = string.Join(",", value.Select(x => x.ToString()));
                }
                base.SetAttribute<string>(nameof(MarketingLists), s);
            }
        }
        public string CrmName
        {
            get
            {
                return base.GetAttribute<string>(nameof(CrmName));
            }

            set
            {
                base.SetAttribute<string>(nameof(CrmName), value);
            }
        }
    }
}