using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Chain
{
    /// <summary>
    /// 审批人
    /// </summary>
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }

        public string Name { get; set; }

        public abstract void ProcessRequest(PurchaseRequest request);

        public Approver(string name)
        {
            Name = name;
        }
    }
}
