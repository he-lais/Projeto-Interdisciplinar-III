namespace DocJur.Api.App.Models.Enums
{
    /// <summary>
    /// Enumeration of field types.
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// Select between yes or no
        /// </summary>
        YesOrNo = 1,

        /// <summary>
        /// Field that contains a money mask in Real
        /// </summary>
        Money = 2,

        /// <summary>
        /// Text input having the max of 20 characters.
        /// </summary>
        Text = 3,

        /// <summary>
        /// Component that lets the user select a date.
        /// </summary>
        Date = 4,

        /// <summary>
        /// Field that contains a CPF mask.
        /// </summary>
        CPF = 5
    }
}
