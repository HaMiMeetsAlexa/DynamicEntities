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
    /// A session is defined as the time a customer invokes the skill until they exit the skill.
    /// A session is deemed complete either when a customer says "Exit", or when the skill times out.
    /// The uploaded dynamic entities time out after 30 minutes, so they will persist if the customer re-invokes the skill before the end of this 30-minute period.
    /// However, a best practice is to re-ingest the dynamic entity catalog in an intent response every session, even if the dynamic entities have not yet expired.
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
