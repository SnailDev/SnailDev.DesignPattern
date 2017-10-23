using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Chain
{
    /// <summary>
    /// 副总经理
    /// </summary>
    public class VicePresident : Approver
    {
        public VicePresident(string name) 
            : base(name)
        {
        }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
            {
                Console.WriteLine("{0}-{1} approved the request of purshing {2}", this.GetType().Name, Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
