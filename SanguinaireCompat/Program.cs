using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using System.Threading.Tasks;
using Mutagen.Bethesda.Plugins;

namespace SanguinaireRacesCompatibility
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SanguinaireRaceCompatibility.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            ModKey skyrim = "Skyrim.esm";
            Keyword vampireKW = new(new(skyrim, 0x0A82BB), SkyrimRelease.SkyrimSE); //Vampire[KYWD: 000A82BB]
            ModKey sanguinaire = "Sanguinaire.esp";
            var vampRacesMap = new Dictionary<FormKey, List<FormKey>>
            {
                {
                    new(skyrim, 0x08883A), //Argonian
                    new List<FormKey>() {
                        new(sanguinaire, 0x260397),
                        new(sanguinaire, 0x260398),
                        new(sanguinaire, 0x260399),
                        new(sanguinaire, 0x26039A),
                        new(sanguinaire, 0x39A2B0),
                        new(sanguinaire, 0x39A2B1),
                        new(sanguinaire, 0x39A2B2),
                        new(sanguinaire, 0x39A2B3),
                        new(sanguinaire, 0x19FC08),
                        new(sanguinaire, 0x830EAF)
                    }
                },
                {
                    new(skyrim, 0x08883C), //Breton
                    new List<FormKey>() {
                        new(sanguinaire, 0x256177),
                        new(sanguinaire, 0x256178),
                        new(sanguinaire, 0x256179),
                        new(sanguinaire, 0x25617A),
                        new(sanguinaire, 0x32AC25),
                        new(sanguinaire, 0x39A2B4),
                        new(sanguinaire, 0x39A2B5),
                        new(sanguinaire, 0x39A2B6),
                        new(sanguinaire, 0x39A2B7),
                        new(sanguinaire, 0x19FC09),
                        new(sanguinaire, 0x830EA4),
                    }
                },
                {
                    new(skyrim, 0x08883D), //Dunmer
                    new List<FormKey>() {
                        new(sanguinaire, 0x25B283),
                        new(sanguinaire, 0x25B284),
                        new(sanguinaire, 0x25B285),
                        new(sanguinaire, 0x25B286),
                        new(sanguinaire, 0x32AC26),
                        new(sanguinaire, 0x39A2B8),
                        new(sanguinaire, 0x39A2B9),
                        new(sanguinaire, 0x39A2BA),
                        new(sanguinaire, 0x39A2BB),
                        new(sanguinaire, 0x19FC0A),
                        new(sanguinaire, 0x830EA5),
                    }
                },
                {
                    new(skyrim, 0x088840), //Altmer
                    new List<FormKey>() {
                        new(sanguinaire, 0x260387),
                        new(sanguinaire, 0x260388),
                        new(sanguinaire, 0x260389),
                        new(sanguinaire, 0x26038A),
                        new(sanguinaire, 0x32AC28),
                        new(sanguinaire, 0x39A2BC),
                        new(sanguinaire, 0x39A2BD),
                        new(sanguinaire, 0x39A2BE),
                        new(sanguinaire, 0x39A2BF),
                        new(sanguinaire, 0x19FC0C),
                        new(sanguinaire, 0x830EA6),
                    }
                },
                {
                    new(skyrim, 0x088844), //Imperial
                    new List<FormKey>() {
                        new(sanguinaire, 0x25617F),
                        new(sanguinaire, 0x256180),
                        new(sanguinaire, 0x256181),
                        new(sanguinaire, 0x256182),
                        new(sanguinaire, 0x32AC29),
                        new(sanguinaire, 0x39A2C0),
                        new(sanguinaire, 0x39A2C1),
                        new(sanguinaire, 0x39A2C2),
                        new(sanguinaire, 0x39A2C3),
                        new(sanguinaire, 0x19FC0D),
                        new(sanguinaire, 0x830EA7),
                    }
                },
                {
                    new(skyrim, 0x088845), //Khajiit
                    new List<FormKey>() {
                        new(sanguinaire, 0x260393),
                        new(sanguinaire, 0x39A2C5),
                        new(sanguinaire, 0x260395),
                        new(sanguinaire, 0x260396),
                        new(sanguinaire, 0x39A2C4),
                        new(sanguinaire, 0x260394),
                        new(sanguinaire, 0x39A2C6),
                        new(sanguinaire, 0x39A2C7),
                        new(sanguinaire, 0x19FC0E),
                        new(sanguinaire, 0x830EB6),
                    }
                },
                {
                    new(skyrim, 0x088794), //Nord
                    new List<FormKey>() {
                        new(sanguinaire, 0x256173),
                        new(sanguinaire, 0x256174),
                        new(sanguinaire, 0x256175),
                        new(sanguinaire, 0x256176),
                        new(sanguinaire, 0x32AC2A),
                        new(sanguinaire, 0x39A2C8),
                        new(sanguinaire, 0x39A2C9),
                        new(sanguinaire, 0x39A2CA),
                        new(sanguinaire, 0x39A2CB),
                        new(sanguinaire, 0x19FC0F),
                        new(sanguinaire, 0x830EA8),
                    }
                },
                {
                    new(skyrim, 0x0A82B9), //Orsimer
                    new List<FormKey>() {
                        new(sanguinaire, 0x26038F),
                        new(sanguinaire, 0x260390),
                        new(sanguinaire, 0x260391),
                        new(sanguinaire, 0x260392),
                        new(sanguinaire, 0x32AC2B),
                        new(sanguinaire, 0x39A2CC),
                        new(sanguinaire, 0x39A2CD),
                        new(sanguinaire, 0x39A2CE),
                        new(sanguinaire, 0x39A2CF),
                        new(sanguinaire, 0x19FC10),
                        new(sanguinaire, 0x830EA9),
                    }
                },
                {
                    new(skyrim, 0x088846), //Redguard
                    new List<FormKey>() {
                        new(sanguinaire, 0x25617B),
                        new(sanguinaire, 0x25617C),
                        new(sanguinaire, 0x25617D),
                        new(sanguinaire, 0x25617E),
                        new(sanguinaire, 0x32AC2C),
                        new(sanguinaire, 0x39A2D0),
                        new(sanguinaire, 0x39A2D1),
                        new(sanguinaire, 0x39A2D2),
                        new(sanguinaire, 0x39A2D3),
                        new(sanguinaire, 0x19FC11),
                        new(sanguinaire, 0x830EAA),
                    }
                },
                {
                    new(skyrim, 0x088884), //Bosmer
                    new List<FormKey>() {
                        new(sanguinaire, 0x26038B),
                        new(sanguinaire, 0x26038C),
                        new(sanguinaire, 0x26038D),
                        new(sanguinaire, 0x26038E),
                        new(sanguinaire, 0x32AC2D),
                        new(sanguinaire, 0x39A2D4),
                        new(sanguinaire, 0x39A2D5),
                        new(sanguinaire, 0x39A2D6),
                        new(sanguinaire, 0x39A2D7),
                        new(sanguinaire, 0x19FC12),
                        new(sanguinaire, 0x830EAB),
                    }
                },
            };

            var vampKeywords = new Dictionary<FormKey, Keyword>();
            foreach (var race in state.LoadOrder.PriorityOrder.Race().WinningOverrides())
            {
                if(vampRacesMap.ContainsKey(race.FormKey))
                {
                    if (!vampKeywords.ContainsKey(race.FormKey))
                        vampKeywords.Add(race.FormKey, state.PatchMod.Keywords.AddNew("KW_" + race.EditorID));
                    var prace = state.PatchMod.Races.GetOrAddAsOverride(race);
                    if (prace.Keywords == null)
                        prace.Keywords = new Noggog.ExtendedList<IFormLinkGetter<IKeywordGetter>>();
                    prace.Keywords.Add(vampKeywords[race.FormKey]);
                }
                foreach (var vampRaces in vampRacesMap)
                {
                    if( vampRaces.Value.Contains(race.FormKey))
                    {
                        if (!vampKeywords.ContainsKey(vampRaces.Key))
                            vampKeywords.Add(vampRaces.Key, state.PatchMod.Keywords.AddNew("KW_" + race.EditorID));
                        var prace = state.PatchMod.Races.GetOrAddAsOverride(race);
                        if (prace.Keywords == null)
                            prace.Keywords = new Noggog.ExtendedList<IFormLinkGetter<IKeywordGetter>>();
                        prace.Keywords.Add(vampKeywords[vampRaces.Key]);
                        break;
                    }
                }
            }

            foreach (var spell in state.LoadOrder.PriorityOrder.WinningOverrides<ISpellGetter>())
            {
                Spell? pSpell = null;
                for (int i = 0; i < spell.Effects.Count; i++)
                {
                    var mgef = spell.Effects[i];
                    for (var j = 0; j < mgef.Conditions.Count; j++)
                    {
                        var cond = mgef.Conditions[j];
                        if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                        var data = (IFunctionConditionDataGetter)cond.Data;

                        // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                        if (data.Function == Condition.Function.HasSpell
                            && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                        {
                            if (pSpell == null) pSpell = state.PatchMod.Spells.GetOrAddAsOverride(spell);
                            UpdateCondition(pSpell.Effects[i].Conditions[j].Data, vampireKW);
                        }

                        // case :: GetIsRace( VampRace )
                        if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                            && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                        {
                            if (pSpell == null) pSpell = state.PatchMod.Spells.GetOrAddAsOverride(spell);
                            UpdateCondition(pSpell.Effects[i].Conditions[j].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                        }
                    }
                }
            }

            foreach (var mgef in state.LoadOrder.PriorityOrder.WinningOverrides<IMagicEffectGetter>())
            {
                MagicEffect? pMGEF = null;
                for (var j = 0; j < mgef.Conditions.Count; j++)
                {
                    var cond = mgef.Conditions[j];
                    if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                    var data = (IFunctionConditionDataGetter)cond.Data;

                    // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                    if (data.Function == Condition.Function.HasSpell
                        && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                    {
                        if (pMGEF == null) pMGEF = state.PatchMod.MagicEffects.GetOrAddAsOverride(mgef);
                        UpdateCondition(pMGEF.Conditions[j].Data, vampireKW);
                    }

                    // case :: GetIsRace( VampRace )
                    if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                        && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                    {
                        if (pMGEF == null) pMGEF = state.PatchMod.MagicEffects.GetOrAddAsOverride(mgef);
                        UpdateCondition(pMGEF.Conditions[j].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                    }
                }
            }

            foreach (var ench in state.LoadOrder.PriorityOrder.WinningOverrides<IObjectEffectGetter>())
            {
                ObjectEffect? pENCH = null;
                for (int i = 0; i < ench.Effects.Count; i++)
                {
                    var mgef = ench.Effects[i];
                    for (var j = 0; j < mgef.Conditions.Count; j++)
                    {
                        var cond = mgef.Conditions[j];
                        if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                        var data = (IFunctionConditionDataGetter)cond.Data;

                        // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                        if (data.Function == Condition.Function.HasSpell
                            && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                        {
                            if (pENCH == null) pENCH = state.PatchMod.ObjectEffects.GetOrAddAsOverride(ench);
                            UpdateCondition(pENCH.Effects[i].Conditions[j].Data, vampireKW);
                        }

                        // case :: GetIsRace( VampRace )
                        if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                            && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                        {
                            if (pENCH == null) pENCH = state.PatchMod.ObjectEffects.GetOrAddAsOverride(ench);
                            UpdateCondition(pENCH.Effects[i].Conditions[j].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                        }
                    }
                }
            }

            foreach (var alch in state.LoadOrder.PriorityOrder.WinningOverrides<IIngestibleGetter>())
            {
                Ingestible? pALCH = null;
                for (int i = 0; i < alch.Effects.Count; i++)
                {
                    var mgef = alch.Effects[i];
                    for (var j = 0; j < mgef.Conditions.Count; j++)
                    {
                        var cond = mgef.Conditions[j];
                        if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                        var data = (IFunctionConditionDataGetter)cond.Data;

                        // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                        if (data.Function == Condition.Function.HasSpell
                            && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                        {
                            if (pALCH == null) pALCH = state.PatchMod.Ingestibles.GetOrAddAsOverride(alch);
                            UpdateCondition(pALCH.Effects[i].Conditions[j].Data, vampireKW);
                        }

                        // case :: GetIsRace( VampRace )
                        if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace )
                            && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                        {
                            if (pALCH == null) pALCH = state.PatchMod.Ingestibles.GetOrAddAsOverride(alch);
                            UpdateCondition(pALCH.Effects[i].Conditions[j].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                        }
                    }
                }
            }

            foreach (var arma in state.LoadOrder.PriorityOrder.WinningOverrides<IArmorAddonGetter>())
            {
                ArmorAddon? pArma = null;
                if( vampRacesMap.Keys.Contains(arma.Race.FormKey) )
                {
                    foreach (var vamp in vampRacesMap[arma.Race.FormKey])
                    {
                        if (!arma.AdditionalRaces.Contains(vamp))
                        {
                            if (pArma == null) pArma = state.PatchMod.ArmorAddons.GetOrAddAsOverride(arma);
                            pArma.AdditionalRaces.Add(vamp);
                        }
                    }
                }
                var racesToAdd = new List<FormKey>();
                foreach( var race in arma.AdditionalRaces)
                {
                    if(vampRacesMap.Keys.Contains(race.FormKey))
                    {
                        foreach (var vamp in vampRacesMap[race.FormKey])
                        {
                            if (!arma.AdditionalRaces.Contains(vamp))
                            {
                                racesToAdd.Add(vamp);
                            }
                        }
                    }
                }
                if (racesToAdd.Count > 0)
                {
                    if (pArma == null) pArma = state.PatchMod.ArmorAddons.GetOrAddAsOverride(arma);
                    pArma.AdditionalRaces.AddRange(racesToAdd);
                }
            }

            foreach (var flist in state.LoadOrder.PriorityOrder.WinningOverrides<IFormListGetter>()
                                    .Where(x => x.ContainedFormLinks.Any(y => vampRacesMap.ContainsKey(y.FormKey)))
                                    .Select(x => state.PatchMod.FormLists.GetOrAddAsOverride(x)))
            {
                foreach (var v in vampRacesMap)
                {
                    if (flist.ContainedFormLinks.Any(x => v.Key == x.FormKey))
                    {
                        flist.Items.AddRange(
                            v.Value.Where( x => !flist.ContainedFormLinks.Any(y => y.FormKey == x) )
                            .Select(x => x.AsLink<Race>())
                        );
                    }
                }
            }

            foreach (var perk in state.LoadOrder.PriorityOrder.Perk().WinningOverrides())
            {
                Perk? pPerk = null;
                for (int i = 0; i < perk.Conditions.Count; i++)
                {
                    var cond = perk.Conditions[i];
                    if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                    var data = (IFunctionConditionDataGetter)cond.Data;

                    // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                    if (data.Function == Condition.Function.HasSpell
                        && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                    {
                        if (pPerk == null) pPerk = state.PatchMod.Perks.GetOrAddAsOverride(perk);
                        UpdateCondition(pPerk.Conditions[i].Data, vampireKW);
                    }

                    // case :: GetIsRace( VampRace )
                    if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                        && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                    {
                        if (pPerk == null) pPerk = state.PatchMod.Perks.GetOrAddAsOverride(perk);
                        UpdateCondition(pPerk.Conditions[i].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                    }
                }

                for (int i = 0; i < perk.Effects.Count; i++)
                {
                    var peff = perk.Effects[i];
                    for (int j = 0; j < peff.Conditions.Count; j++)
                    {
                        var pcond = peff.Conditions[j];
                        for (int k = 0; k < pcond.Conditions.Count; k++)
                        {
                            var cond = pcond.Conditions[k];
                            if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                            var data = (IFunctionConditionDataGetter)cond.Data;

                            // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                            if (data.Function == Condition.Function.HasSpell
                                && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                            {
                                if (pPerk == null) pPerk = state.PatchMod.Perks.GetOrAddAsOverride(perk);
                                UpdateCondition(pPerk.Effects[i].Conditions[j].Conditions[k].Data, vampireKW);
                            }

                            // case :: GetIsRace( VampRace )
                            if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                                && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                            {
                                if (pPerk == null) pPerk = state.PatchMod.Perks.GetOrAddAsOverride(perk);
                                UpdateCondition(pPerk.Effects[i].Conditions[j].Conditions[k].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                            }
                        }
                    }
                }
            }

            var seenResponses = new HashSet<FormKey>();
            foreach (var dial in state.LoadOrder.PriorityOrder.DialogTopic().WinningOverrides())
            {
                DialogTopic? pDial = null;

                var topicOverrides = dial.AsLink().ResolveAll(state.LinkCache);
                foreach (var dialogTopic in topicOverrides)
                {
                    for (var i = 0; i < dialogTopic.Responses.Count; i++)
                    {
                        DialogResponses? pInfo = null;
                        var info = dialogTopic.Responses[i];
                        if (!seenResponses.Add(info.FormKey)) continue;
                        for (var j = 0; j < info.Conditions.Count; j++)
                        {
                            var cond = info.Conditions[j];
                            if (!(cond.Data is IFunctionConditionDataGetter)) continue;
                            var data = (IFunctionConditionDataGetter)cond.Data;

                            // case :: HasSpell(WVR_VampireVampirism "Vampirism" [SPEL:000ED0A8])
                            if (data.Function == Condition.Function.HasSpell
                                && data.ParameterOneRecord.FormKey.ModKey.Equals(skyrim) && data.ParameterOneRecord.FormKey.ID == 0x0ED0A8)
                            {
                                if (pInfo == null) pInfo = info.DeepCopy();
                                if (pDial == null)
                                {
                                    pDial = state.PatchMod.DialogTopics.GetOrAddAsOverride(dial);
                                    pDial.Responses.Add(pInfo);
                                }
                                UpdateCondition(pInfo.Conditions[j].Data, vampireKW );
                            }

                            // case :: GetIsRace( VampRace )
                            if ((data.Function == Condition.Function.GetIsRace || data.Function == Condition.Function.GetPCIsRace)
                                && vampKeywords.ContainsKey(data.ParameterOneRecord.FormKey))
                            {
                                if (pInfo == null) pInfo = info.DeepCopy();
                                if (pDial == null)
                                {
                                    pDial = state.PatchMod.DialogTopics.GetOrAddAsOverride(dial);
                                    pDial.Responses.Add(pInfo);
                                }
                                UpdateCondition(pInfo.Conditions[j].Data, vampKeywords[data.ParameterOneRecord.FormKey]);
                            }
                        }
                    }
                }
            }
        }

        private static void UpdateCondition(ConditionData cData, Keyword keyword)
        {
            var fData = (FunctionConditionData)cData;
            fData.Function = Condition.Function.HasKeyword;
            fData.ParameterOneRecord = keyword.AsLink();
        }

        public static void RunPatch_SanguinaireOpt(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {   // not used.
            var playerRefKey = new FormKey("Skyrim.esm", 0x014).AsLink<ISkyrimMajorRecordGetter>();
            foreach (var quest in state.LoadOrder.PriorityOrder.WinningOverrides<IQuestGetter>())
            {
                Quest? pq = null;
                if (quest.VirtualMachineAdapter == null) continue;
                foreach (var script in quest.VirtualMachineAdapter.Scripts)
                {
                    if (script.Name.StartsWith("SN_", StringComparison.InvariantCultureIgnoreCase))
                    {
                        bool hasPlayerRef = false;
                        foreach (var prop in script.Properties)
                            hasPlayerRef |= prop.Name.Equals("PlayerRef", StringComparison.InvariantCultureIgnoreCase);
                        if (hasPlayerRef) continue;

                        // create patch quest
                        if (pq == null) pq = state.PatchMod.Quests.GetOrAddAsOverride(quest);
                        if (pq.VirtualMachineAdapter == null) continue;
                        foreach (var ps in pq.VirtualMachineAdapter.Scripts)
                        {
                            if (!ps.Name.Equals(script.Name)) continue;
                            ScriptObjectProperty playerRef = new();
                            playerRef.Name = "PlayerRef";
                            playerRef.Flags = ScriptProperty.Flag.Edited;
                            playerRef.Object = playerRefKey;
                            ps.Properties.Add(playerRef);
                            Console.WriteLine($"Added PlayerRef to {script.Name} of [QUEST:{quest.EditorID}] {quest.Name}");
                            break;
                        }
                    }
                }
            }

            foreach( var mgef in state.LoadOrder.PriorityOrder.WinningOverrides<IMagicEffectGetter>())
            {
                MagicEffect? mp = null;
                if (mgef.VirtualMachineAdapter == null) continue;
                foreach (var script in mgef.VirtualMachineAdapter.Scripts)
                {
                    if (script.Name.StartsWith("SN_", StringComparison.InvariantCultureIgnoreCase))
                    {
                        bool hasPlayerRef = false;
                        foreach (var prop in script.Properties)
                            hasPlayerRef |= prop.Name.Equals("PlayerRef", StringComparison.InvariantCultureIgnoreCase);
                        if (hasPlayerRef) continue;

                        // create patch quest
                        if (mp == null) mp = state.PatchMod.MagicEffects.GetOrAddAsOverride(mgef);
                        if (mp.VirtualMachineAdapter == null) continue;
                        foreach (var ps in mp.VirtualMachineAdapter.Scripts)
                        {
                            if (!ps.Name.Equals(script.Name)) continue;
                            ScriptObjectProperty playerRef = new();
                            playerRef.Name = "PlayerRef";
                            playerRef.Flags = ScriptProperty.Flag.Edited;
                            playerRef.Object = playerRefKey;
                            ps.Properties.Add(playerRef);
                            Console.WriteLine($"Added PlayerRef to {script.Name} of [MGEF:{mgef.EditorID}] {mgef.Name}");
                            break;
                        }
                    }
                }
            }
        }
    }
}
