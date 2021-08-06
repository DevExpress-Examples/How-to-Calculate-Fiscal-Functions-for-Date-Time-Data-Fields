using DevExpress.Data.Filtering;
using System;
using System.Linq;

namespace Dashboard_FiscalFunctions {
    class GetFiscalYearFunction : GetFiscalDateFunction {

        public GetFiscalYearFunction(int startDay, int startMonth) : base(startDay, startMonth) { }

        protected override int GetFiscal(DateTime current) {
            if(current.Month > startMonth) {
                return current.Year + 1;
            } else if(current.Month < startMonth) {
                return current.Year;
            } else {
                if(current.Day >= startDay) {
                    return current.Year + 1;
                } else {
                    return current.Year;
                }
            }
        }

        public override string Description => "GetFiscalYear(DateTime) \n Extracts a fiscal year from the defined DateTime";

        public override string Name => "GetFiscalYear";
    }
}
