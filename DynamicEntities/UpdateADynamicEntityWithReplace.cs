// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateADynamicEntityWithReplace.cs" company="Millmann.Biz">
//   (c) 2022 by Hans Ludwig Millmann
// </copyright>
// <summary>
//   The update a dynamic entity with replace.
//   <see>
//   <cref>https://developer.amazon.com/en-US/docs/alexa/custom-skills/use-dynamic-entities-for-customized-interactions.html#exampleupdate-a-dynamic-entity-with-replace</cref>
//   </see>
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
        /// The create slot type values.
        /// </summary>
        /// <returns>
        /// The <see cref="SlotTypeValue[]"/>.
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
        /// Create the slot type with <param name="slotTypeName"/>
        /// and the values<param name="slotTypeValues"/>.
        /// </summary>
        /// <param name="slotTypeName">
        /// The slot type name.
        /// </param>
        /// <param name="slotTypeValues">
        /// The slot type values.
        /// </param>
        /// <returns>
        /// The <see cref="SlotType"/>.
        /// </returns>
        private static SlotType CreateSlotType(
            string slotTypeName, 
            SlotTypeValue[] slotTypeValues)
        {
            var slot = new SlotType { Name = slotTypeName, Values = slotTypeValues };

            return slot;
        }

        /// <summary>
        /// Create a replace directive for the given <param name="slotType"/>.
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
