using Sonosthesia.AdaptiveMIDI.Messages;
using Sonosthesia.Flow;
using Sonosthesia.Spawn;
using Sonosthesia.Utils;
using UnityEngine;

namespace Sonosthesia.Link
{
    public class MIDISpawnChannelLink : DynamicChannelLink<MIDINote, SpawnPayload>
    {
        [SerializeField] private Mapper<MIDINote, Color> _colorMapper;

        [SerializeField] private Mapper<MIDINote, Vector3> _positionMapper;

        [SerializeField] private Mapper<MIDINote, Vector3> _scaleMapper;

        [SerializeField] private Mapper<MIDINote, float> _sizeMapper;
        
        [SerializeField] private Mapper<MIDINote, float> _lifetimeMapper;
        
        protected override SpawnPayload Map(MIDINote payload)
        {
            Vector3 position = _positionMapper ? _positionMapper.Map(payload) : Vector3.zero;
            Vector3 scale = _scaleMapper ? _scaleMapper.Map(payload) : Vector3.one;
            float size = _sizeMapper ? _sizeMapper.Map(payload) : 1f;
            float lifetime = _lifetimeMapper ? _lifetimeMapper.Map(payload) : 1f;
            Color color = _colorMapper ? _colorMapper.Map(payload) : Color.white;
            
            return new SpawnPayload(
                new Trans(position, Quaternion.identity, scale),
                size,
                lifetime,
                color,
                Vector3.zero, 
                Vector3.zero);
        }
    }
}