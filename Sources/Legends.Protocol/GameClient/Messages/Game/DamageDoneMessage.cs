﻿using System;
using System.Collections.Generic;
using System.Linq;
using Legends.Core.Protocol;
using System.Threading.Tasks;
using Legends.Core.IO;
using Legends.Protocol.GameClient.Enum;

namespace Legends.Protocol.GameClient.Messages.Game
{
    public class DamageDoneMessage : BaseMessage
    {
        public static PacketCmd PACKET_CMD = PacketCmd.PKT_S2C_DamageDone;
        public override PacketCmd Cmd => PACKET_CMD;

        public static Channel CHANNEL = Channel.CHL_GAMEPLAY;
        public override Channel Channel => CHANNEL;

        public DamageResultEnum damageResult;
        public DamageType damageType;
        public float value;
        public uint targetNetId;
        public uint sourceNetId;

        public DamageDoneMessage(DamageResultEnum damageResult, DamageType damageType, float value, uint targetNetId, uint sourceNetId) : base(targetNetId)
        {
            this.damageResult = damageResult;
            this.damageType = damageType;
            this.value = value;
            this.targetNetId = targetNetId;
            this.sourceNetId = sourceNetId;
        }
        public DamageDoneMessage()
        {

        }

        public override void Deserialize(LittleEndianReader reader)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(LittleEndianWriter writer)
        {
            writer.WriteByte((byte)damageResult);
            writer.WriteShort((short)((short)damageType << 8));
            writer.WriteFloat((float)value);
            writer.WriteUInt(targetNetId);
            writer.WriteUInt(sourceNetId);
        }
    }
}
