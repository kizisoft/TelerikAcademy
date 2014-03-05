using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class EnhancedHoldingPen : HoldingPen
    {

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    var powerCatalyst = new PowerCatalyst();
                    Unit targetUnit = this.GetUnit(commandWords[2]);
                    targetUnit.AddSupplement(powerCatalyst);
                    break;
                case "HealthCatalyst":
                    var healthCatalyst = new HealthCatalyst();
                    targetUnit = this.GetUnit(commandWords[2]);
                    targetUnit.AddSupplement(healthCatalyst);
                    break;
                case "AggressionInhibitor":
                    var aggressionCatalyst = new AggressionCatalyst();
                    targetUnit = this.GetUnit(commandWords[2]);
                    targetUnit.AddSupplement(aggressionCatalyst);
                    break;
                case "Weapon":
                    var weapon = new Weapon();
                    targetUnit = this.GetUnit(commandWords[2]);
                    targetUnit.AddSupplement(weapon);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    {
                        Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                        Unit unit = this.GetUnit(interaction.SourceUnit);

                        var infestor = unit as Parasite;

                        if (infestor != null)
                        {
                            var infestationSpores = new InfestationSpores();
                            targetUnit.AddSupplement(infestationSpores);
                        }

                        //targetUnit.DecreaseBaseHealth(interaction.SourceUnit.Power);
                        break;
                    }
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }
        }
    }
}