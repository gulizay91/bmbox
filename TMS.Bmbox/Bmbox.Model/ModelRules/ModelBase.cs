using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Model.ModelRules
{
  public abstract class ModelBase
  {
    public Nullable<Guid> TenantId { get; set; }

    private List<BusinessRule> _brokenRules = new List<BusinessRule>();

    protected abstract void Validate();

    public IEnumerable<BusinessRule> GetBrokenRules()
    {
      _brokenRules.Clear();
      Validate();
      return _brokenRules;
    }

    protected void AddBrokenRule(BusinessRule businessRule)
    {
      _brokenRules.Add(businessRule);
    }
    protected void AddRangeBrokenRule(IEnumerable<BusinessRule> businessRules)
    {
      _brokenRules.AddRange(businessRules);
    }

    internal void AddBrokenRule(object nameMaxLength)
    {
      throw new NotImplementedException();
    }

    public override bool Equals(object entity)
    {
      return entity != null && entity is ModelBase && this == (ModelBase)entity;
    }

    public static bool operator ==(ModelBase entity1, ModelBase entity2)//== operatorünü operatör overloading ile ezerek kolay kullanım sağladık.
    {
      if ((object)entity1 == null && (object)entity2 == null)
      {
        return true;
      }

      if ((object)entity1 == null || (object)entity2 == null)
      {
        return false;
      }

      return false;
    }

    public static bool operator !=(ModelBase entity1, ModelBase entity2)
    {
      return (!(entity1 == entity2));
    }
  }
}
