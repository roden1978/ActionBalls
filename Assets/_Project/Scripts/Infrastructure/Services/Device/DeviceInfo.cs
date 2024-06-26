using UnityEngine;
using Zenject;
using Screen = UnityEngine.Device.Screen;

namespace Infrastructure.Services
{
    public class DeviceInfo : IInitializable
    {
        public DeviceData DeviceData => _deviceData;
        private DeviceData _deviceData;
        private const int PlayerAreaHeight = 200; 
        
        public void Initialize()
        {
            _deviceData = new DeviceData
            {
                ScreenWidth = Screen.width,
                ScreenHeight = Screen.height,
                PlayerAreaHeight = PlayerAreaHeight
            };
            
            Debug.Log(_deviceData.ToString());
        }

    }

    public class DeviceData
    {
        public int ScreenWidth;
        public int ScreenHeight;
        public int PlayerAreaHeight;

        public override string ToString()
        {
            return $"Width: {ScreenWidth}, height: {ScreenHeight}, player area: {PlayerAreaHeight}";
        }
    }

}