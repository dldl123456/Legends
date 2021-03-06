﻿using System;
using System.Collections.Generic;
using System.Linq;
using Legends.Core.Protocol;
using System.Threading.Tasks;
using Legends.Core.IO;
using Legends.Protocol.GameClient.Enum;

namespace Legends.Protocol.GameClient.Messages.Game
{
    public class MovementRequestMessage : BaseMessage
    {
        public static PacketCmd PACKET_CMD = PacketCmd.PKT_C2S_MoveReq;
        public override PacketCmd Cmd => PACKET_CMD;

        public static Channel CHANNEL = Channel.CHL_C2S;
        public override Channel Channel => CHANNEL;

        public MovementType type;
        public float x;
        public float y;
        public uint targetNetId;
        public byte coordCount;
        public int netId2;
        public byte[] moveData;
            
        public MovementRequestMessage()
        {

        }
        public override void Deserialize(LittleEndianReader reader)
        {
            this.type = (MovementType)reader.ReadByte();
            this.x = reader.ReadFloat();
            this.y = reader.ReadFloat();
            this.targetNetId = reader.ReadUInt();
            this.coordCount = reader.ReadByte();
            this.netId2 = reader.ReadInt();
            this.moveData = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
        }

        public override void Serialize(LittleEndianWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
