using UnityEngine.Device;
using Zenject;

namespace Infrastructure.Services
{
    public class DeviceInfo : IInitializable
    {
        public DeviceData DeviceData => _deviceData;
        private readonly DeviceData _deviceData;

        public DeviceInfo()
        {
            _deviceData = new DeviceData();
        }
        public void Initialize()
        {
            _deviceData.ScreenWidth = Screen.width;
            _deviceData.ScreenHeight = Screen.height;
        }

    }

    public class DeviceData
    {
        public int ScreenWidth;
        public int ScreenHeight;
    }

}