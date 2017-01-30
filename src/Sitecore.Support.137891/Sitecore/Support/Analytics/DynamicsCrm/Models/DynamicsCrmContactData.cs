using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.DynamicsCrm.Models;
using Sitecore.Connect.Crm.Local.Models;

namespace Sitecore.Support.Analytics.DynamicsCrm.Models
{
  [Serializable]
  public class DynamicsCrmContactData : Facet, IDynamicsCrmContactData, ICrmContactData<Guid, Guid>, IFacet, IElement, IValidatable
  {
    public DynamicsCrmContactData()
    {
      base.EnsureAttribute<Guid>("ContactId");
      base.EnsureAttribute<string>("MarketingLists");
      base.EnsureAttribute<DateTime>("LastSynced");
      base.EnsureAttribute<string>("CrmName");
    }

    // Properties
    public Guid ContactId
    {
      get
      {
        return base.GetAttribute<Guid>("ContactId");
      }
      set
      {
        base.SetAttribute<Guid>("ContactId", value);
      }
    }

    public string CrmName
    {
      get
      {
        return base.GetAttribute<string>("CrmName");
      }
      set
      {
        base.SetAttribute<string>("CrmName", value);
      }
    }

    public DateTime LastSynced
    {
      get
      {
        return base.GetAttribute<DateTime>("LastSynced");
      }
      set
      {
        base.SetAttribute<DateTime>("LastSynced", value);
      }
    }

    public ICollection<Guid> MarketingLists
    {
      get
      {
        List<Guid> list = new List<Guid>();
        string attribute = base.GetAttribute<string>("MarketingLists");
        if (attribute != null)
        {
          char[] separator = new char[] { ',' };
          using (List<string>.Enumerator enumerator = attribute.Split(separator).ToList<string>().GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              Guid item = Guid.Parse(enumerator.Current);
              list.Add(item);
            }
          }
        }
        return list;
      }
      set
      {
        string str = null;
        if ((value != null) && value.Any<Guid>())
        {
          str = string.Join(",", (IEnumerable<string>)(from x in value select x.ToString()));
        }
        base.SetAttribute<string>("MarketingLists", str);
      }
    }
  }
}