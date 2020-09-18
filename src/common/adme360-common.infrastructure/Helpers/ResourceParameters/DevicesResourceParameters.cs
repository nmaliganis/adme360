namespace adme360.common.infrastructure.Helpers.ResourceParameters
{
    public class DevicesResourceParameters : BaseResourceParameters
    {
        /// <summary>
        /// <param name="Filter">Filter in Field
        /// (id, imei, serial number e.t.c.)</param>
        /// </summary>
        public override string Filter { get; set; }

        /// <summary>
        /// <param name="SearchQuery">Search into Fields
        /// (id, imei, serial number e.t.c.)</param>
        /// </summary> 
        public override string SearchQuery { get; set; }

        /// <summary>
        /// <param name="Fields">Fields to be Shown
        /// (id, imei, serial number e.t.c.)</param>
        /// </summary>
        public override string Fields { get; set; }

        /// <summary>
        /// <param name="OrderBy">Order by specific field 
        /// (id, imei, serial number e.t.c.)</param>
        /// </summary> 
        public override string OrderBy { get; set; } = "SerialNumber";
    }
}