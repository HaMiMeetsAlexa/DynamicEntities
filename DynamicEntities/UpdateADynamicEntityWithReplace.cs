// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateADynamicEntityWithReplace.cs" company="Millmann.Biz">
//   (c) 2022 by Hans Ludwig Millmann
// </copyright>
// <summary>
//   Defines the UpdateADynamicEntityWithReplace type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicEntities.Test")]

namespace DynamicEntities
{
    using Alexa.NET;
    using Alexa.NET.Response;
    using Alexa.NET.Response.Directive;

    /// <summary>
    /// The update a dynamic entity with replace.
    /// <see>
    ///     <cref>https://developer.amazon.com/en-US/docs/alexa/custom-skills/use-dynamic-entities-for-customized-interactions.html#exampleupdate-a-dynamic-entity-with-replace</cref>
    /// </see>
    /// </summary>
    [Serializable]
    internal sealed class UpdateADynamicEntityWithReplace
    {
        /// <summary>
        /// The create skill response.
        /// </summary>
        /// <returns>
        /// The <see cref="SkillResponse"/>.
        /// </returns>
        public static SkillResponse CreateSkillResponse()
        {
            var slotTypeValues = CreateSlotTypeValues();

            var slotType = CreateSlotType("AirportSlotType", slotTypeValues);

            var directive = CreateReplaceDirective(slotType);

            const string Repeat = "What airport would you like to depart from?";
            const string Speech = $"Thank you for flying with us. {Repeat}";

            var skillResponse = ResponseBuilder.Ask(Speech, new Reprompt(Repeat));
            skillResponse.Response.Directives.Add(directive);

            return skillResponse;
        }

        /// <summary>
        /// Create slot type values.
        /// Values are taken from Amazon example
        /// </summary>
        /// <returns>
        /// The <see>
        ///     <cref>SlotTypeValue[]</cref>
        /// </see>
        /// </returns>
        private static SlotTypeValue[] CreateSlotTypeValues()
        {
            SlotTypeValue[] values =
            {
                new SlotTypeValue()
                {
                    Id = "SJC",
                    Name = new SlotTypeValueName
                           {
                               Value = "San Jose International Airport",
                               Synonyms = new[] { "San Jose", "SJC" }
                           }
                },
                new SlotTypeValue()
                {
                    Id = "JFK",
                    Name = new SlotTypeValueName
                           {
                               Value = "John F. Kennedy International Airport",
                               Synonyms = new[] { "New York", "LGA" }
                           }
                },
                new SlotTypeValue()
                {
                    Id = "LGA",
                    Name = new SlotTypeValueName
                           {
                               Value = "Logan International Airport",
                               Synonyms = new[] { "beantown", "bean town", "the hub", "logan" }
                           }
                },
            };

            return values;
        }

        /// <summary>
        /// The create slot type.
        /// </summary>
        /// <param name="slotTypeName">
        /// The slot type name.
        /// </param>
        /// <param name="slotTypeValues">
        /// The slot type values names.
        /// </param>
        /// <returns>
        /// The <see cref="SlotType"/>.
        /// </returns>
        private static SlotType CreateSlotType(string slotTypeName, SlotTypeValue[] slotTypeValues)
        {
            var slot = new SlotType { Name = slotTypeName, Values = slotTypeValues };

            return slot;
        }

        /// <summary>
        /// The create replace directive.
        /// </summary>
        /// <param name="slotType">
        /// The slot type.
        /// </param>
        /// <returns>
        /// The <see cref="IDirective"/>.
        /// </returns>
        private static IDirective CreateReplaceDirective(SlotType slotType)
        {
            var dialogUpdateDynamicEntities =
                new DialogUpdateDynamicEntities
                {
                    UpdateBehavior = UpdateBehavior.Replace
                };

            dialogUpdateDynamicEntities.Types.Add(slotType);

            return dialogUpdateDynamicEntities;
        }
    }
}
