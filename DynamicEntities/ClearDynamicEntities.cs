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
    /// Although dynamic entities will persist for 30 minutes, which may be longer than the customer's skill session,
    /// a best practice is to "expire" the dynamic entities at the end of a session, that is to delete them.
    /// To delete dynamic entities, as you might do when the customer exits the skill,
    /// call the Dialog.DynamicEntityDirective CLEAR function to clear all dynamic entities for that customer, as shown in the following example.
    /// <see>
    ///     <cref>https://developer.amazon.com/en-US/docs/alexa/custom-skills/use-dynamic-entities-for-customized-interactions.html#expire-dynamic-entities-at-the-end-of-a-session</cref>
    /// </see>
    /// </summary>
    [Serializable]
    internal sealed class ClearDynamicEntities
    {
        /// <summary>
        /// Expire dynamic entities at the end of a session.
        /// </summary>
        /// <returns>
        /// The <see cref="DialogUpdateDynamicEntities"/>.
        /// </returns>
        public static IDirective Clear()
        {
            var dialogUpdateDynamicEntities =
                new DialogUpdateDynamicEntities
                {
                    UpdateBehavior = UpdateBehavior.Clear
                };

            return dialogUpdateDynamicEntities;
        }
    }
}
