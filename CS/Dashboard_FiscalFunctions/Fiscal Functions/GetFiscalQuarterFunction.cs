using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_FiscalFunctions {
    class GetFiscalQuarterFunction : GetFiscalDateFunction {
        public GetFiscalQuarterFunction(int startDay, int startMonth) : base(startDay, startMonth) {}

        public override string Name => "GetFiscalQuarter";

        public override string Description => "GetFiscalQuarter(DateTime) \n Extracts a fiscal quarter from the defined DateTime.";

        protected override int GetFiscal(DateTime current) {
            int currentMonth = current.Month;
            if ((current.Month + 12 - startMonth) % 3 == 0) {
                currentMonth += current.Day < startDay ? -1 : 1;
            }
            int offset = currentMonth < startMonth ? 12 : 0;
            return (currentMonth - startMonth + offset) / 3 + 1;
        }
    }
}
