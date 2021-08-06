using DevExpress.Data.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_FiscalFunctions {
    abstract class GetFiscalDateFunction : ICustomFunctionOperatorBrowsable {
        protected int startDay;
        protected int startMonth;

        protected GetFiscalDateFunction(int startDay, int startMonth) {
            this.startDay = startDay;
            this.startMonth = startMonth;
        }
   
        protected abstract int GetFiscal(DateTime current);
        public int MinOperandCount => 1;

        public int MaxOperandCount => 1;

        public abstract string Description { get; }

        public FunctionCategory Category => FunctionCategory.DateTime;

        public abstract string Name { get; }

        public object Evaluate(params object[] operands) {
            return GetFiscal((DateTime) operands[0]);
        }

        public bool IsValidOperandCount(int count) {
            return count == 1;
        }

        public bool IsValidOperandType(int operandIndex, int operandCount, Type type) {
            return type == typeof(DateTime) && operandCount == 1 && operandIndex == 0;
        }

        public Type ResultType(params Type[] operands) {
            return typeof(int);
        }
    }
}
