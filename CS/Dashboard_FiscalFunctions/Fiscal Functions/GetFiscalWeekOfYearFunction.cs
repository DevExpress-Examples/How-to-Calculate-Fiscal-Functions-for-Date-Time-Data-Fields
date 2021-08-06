using System;
using System.Globalization;
using System.Linq;

namespace Dashboard_FiscalFunctions {
    class GetFiscalWeekOfYearFunction : GetFiscalDateFunction {
        CalendarWeekRule rule;
        DayOfWeek firstDay;

        public GetFiscalWeekOfYearFunction(int startDay, int startMonth, CalendarWeekRule rule, DayOfWeek firstDay) : base(startDay, startMonth) {
            this.rule = rule;
            this.firstDay = firstDay;
        }

        public override string Name => "GetFiscalWeekOfYear";

        public override string Description => "GetFiscalWeek(DateTime) \n Extracts a fiscal week of the year from the defined DateTime";

        int WeekCounts(DateTime current, int difference) {
            for(int i = 1; i < difference; i++) {
                if(((int)current.DayOfWeek + i + 7) % 7 == (int)firstDay) {
                    return i;
                }
            }
            return -1;
        }

        DateTime Beginning(int currentYear) {
            DateTime start = new DateTime(currentYear, startMonth, startDay);
            if(rule == CalendarWeekRule.FirstDay) {
                return start;
            } else {
                int range;
                if(rule == CalendarWeekRule.FirstFourDayWeek) {
                    range = WeekCounts(start, 4);
                } else {
                    range = WeekCounts(start, 7);
                }
                if(range == -1) {
                    return start;
                } else {
                    return start.AddDays(range);
                }
            }
        }

        protected override int GetFiscal(DateTime current) {
            DateTime start = Beginning(current.Year);
            if(current < start) {
                start = Beginning(current.Year - 1);
            }
            int plus = (start.DayOfWeek - firstDay + 7) % 7;
            return ((int)(current - start).TotalDays + plus) / 7 + 1;
        }
    }
}
