﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bmbox.Model.ModelRules
{
  public class BusinessRule
  {
    private string _property;
    private string _rule;

    public BusinessRule(string property, string rule)
    {
      _property = property;
      _rule = rule;
    }

    public string Property
    {
      get { return _property; }
      set { _property = value; }
    }

    public string Rule
    {
      get { return _rule; }
      set { _rule = value; }
    }
  }
}
