using System;
using System.Collections.Generic;
using System.Text;

namespace PFF.Domain.Model.Enum
{
    public enum ConsumptionFrequencyEnum
    {
        MultipleTimesADay = 0,
        OnceADay = 1,
        BetweenOnceADayAndOnceAWeek = 2,
        OnceAWeek = 3,
        BetweenOnceAWeekAndOnceAMonth = 4,
        OnceAMonth = 5,
        LessThanOnceAMonth = 6
    }
}
