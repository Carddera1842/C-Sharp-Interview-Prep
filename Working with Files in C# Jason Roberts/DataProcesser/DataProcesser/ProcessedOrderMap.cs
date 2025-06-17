using CsvHelper.Configuration;
using System.Globalization;

namespace DataProcesser;

internal class ProcessedOrderMap : ClassMap<ProcessedOrder>
{
    public ProcessedOrderMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(po => po.Customer).Name("CustomerNumber");
        Map(po => po.Amount).Name("Quantity").TypeConverter<RomanTypeConverter>();
    }
}
