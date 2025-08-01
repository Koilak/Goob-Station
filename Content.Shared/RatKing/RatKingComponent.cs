// SPDX-FileCopyrightText: 2023 Kara <lunarautomaton6@gmail.com>
// SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Whisper <121047731+QuietlyWhisper@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Aiden <28298836+Aidenkrz@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 GoobBot <uristmchands@proton.me>
// SPDX-FileCopyrightText: 2025 OnsenCapy <101037138+OnsenCapy@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 SX-7 <sn1.test.preria.2002@gmail.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.RatKing;

[RegisterComponent, NetworkedComponent, Access(typeof(SharedRatKingSystem))]
[AutoGenerateComponentState]
public sealed partial class RatKingComponent : Component
{
    [DataField("actionRaiseArmy", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionRaiseArmy = "ActionRatKingRaiseArmy";

    /// <summary>
    ///     The action for the Raise Army ability
    /// </summary>
    [DataField("actionRaiseArmyEntity")]
    public EntityUid? ActionRaiseArmyEntity;

    /// <summary>
    ///     The amount of hunger one use of Raise Army consumes
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField("hungerPerArmyUse", required: true)]
    public float HungerPerArmyUse = 25f;

    /// <summary>
    ///     The entity prototype of the mob that Raise Army summons
    /// </summary>
    [ViewVariables(VVAccess.ReadWrite), DataField("armyMobSpawnId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ArmyMobSpawnId = "MobRatServant";

    [DataField("actionDomain", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionDomain = "ActionRatKingDomain";

    /// <summary>
    ///     The action for the Domain ability
    /// </summary>
    [DataField("actionDomainEntity")]
    public EntityUid? ActionDomainEntity;

    /// <summary>
    ///     The amount of hunger one use of Domain consumes
    /// </summary>
    [DataField("hungerPerDomainUse", required: true), ViewVariables(VVAccess.ReadWrite)]
    public float HungerPerDomainUse = 50f;

    /// <summary>
    ///     How many moles of ammonia are released after one use of Domain
    /// </summary>
    [DataField("molesAmmoniaPerDomain"), ViewVariables(VVAccess.ReadWrite)]
    public float MolesAmmoniaPerDomain = 300f;

    /// <summary>
    /// The current order that the Rat King assigned.
    /// </summary>
    [DataField("currentOrders"), ViewVariables(VVAccess.ReadWrite)]
    [AutoNetworkedField]
    public RatKingOrderType CurrentOrder = RatKingOrderType.Loose;

    /// <summary>
    /// The servants that the rat king is currently controlling
    /// </summary>
    [DataField("servants")]
    public HashSet<EntityUid> Servants = new();

    [DataField("actionOrderStay", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionOrderStay = "ActionRatKingOrderStay";

    [DataField("actionOrderStayEntity")]
    public EntityUid? ActionOrderStayEntity;

    [DataField("actionOrderFollow", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionOrderFollow = "ActionRatKingOrderFollow";

    [DataField("actionOrderFollowEntity")]
    public EntityUid? ActionOrderFollowEntity;

    [DataField("actionOrderCheeseEm", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionOrderCheeseEm = "ActionRatKingOrderCheeseEm";

    [DataField("actionOrderCheeseEmEntity")]
    public EntityUid? ActionOrderCheeseEmEntity;

    [DataField("actionOrderLoose", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string ActionOrderLoose = "ActionRatKingOrderLoose";

    [DataField("actionOrderLooseEntity")]
    public EntityUid? ActionOrderLooseEntity;

    /// <summary>
    /// A dictionary with an order type to the corresponding callout dataset.
    /// </summary>
    [DataField("orderCallouts")]
    public Dictionary<RatKingOrderType, string> OrderCallouts = new()
    {
        { RatKingOrderType.Stay, "RatKingCommandStay" },
        { RatKingOrderType.Follow, "RatKingCommandFollow" },
        { RatKingOrderType.CheeseEm, "RatKingCommandCheeseEm" },
        { RatKingOrderType.Loose, "RatKingCommandLoose" }
    };
}

[Serializable, NetSerializable]
public enum RatKingOrderType : byte
{
    Stay,
    Follow,
    CheeseEm,
    Loose
}
