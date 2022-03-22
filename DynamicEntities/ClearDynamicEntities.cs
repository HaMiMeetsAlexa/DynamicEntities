// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearDynamicEntities.cs" company="Millmann.Biz">
//   (c) 2022 by Hans Ludwig Millmann
// </copyright>
// <summary>
//   Delete dynamic entities.
//   <see>
//   <cref>https://developer.amazon.com/en-US/docs/alexa/custom-skills/use-dynamic-entities-for-customized-interactions.html#expire-dynamic-entities-at-the-end-of-a-session</cref>
//   </see>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DynamicEntities
{
    using Alexa.NET.Response;
    using Alexa.NET.Response.Directive;

    /// <summary>
    /// Delete dynamic entities.
    /// <see>
    ///     <cref>https://developer.amazon.com/en-US/docs/alexa/custom-skills/use-dynamic-entities-for-customized-interactions.html#expire-dynamic-entities-at-the-end-of-a-session</cref>
    /// </see>
    /// </summary>
    [Serializable]
    internal sealed class ClearDynamicEntities
    {
        /// <summary>
        /// Clear the entities from slot.
        /// </summary>
        /// <param name="slotTypeName">
        /// "Name" of <see cref="SlotTypeValue"/> to clear.
        /// </param>
        /// <returns>
        /// The <see cref="DialogUpdateDynamicEntities"/>.
        /// </returns>
        public static IDirective Clear(string slotTypeName)
        {
            var dialogUpdateDynamicEntities =
                new DialogUpdateDynamicEntities
                {
                    UpdateBehavior = UpdateBehavior.Clear
                };

            var slot = new SlotType { Name = slotTypeName };

            dialogUpdateDynamicEntities.Types.Add(slot);

            return dialogUpdateDynamicEntities;
        }
    }
}
