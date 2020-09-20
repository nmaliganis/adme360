using System;
using System.Text;

namespace dl.wm.presenter.Helpers
{
    public static class Messages
    {
        public static string BuildMessageForGetDlStatus(string message, byte[] deviceId,
                                                 byte dl1Status, int dl2Status)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: ");
            sb.Append(dt);
            sb.Append("\n");

            sb.AppendLine("Details: ");
            sb.Append("DeviceID: "); foreach (var b in deviceId)
            {
                sb.Append($"{b:X}");
                sb.Append(" ");
            }

            sb.Append("\n");
            sb.Append("DL 1 Status: ");
            sb.Append(dl1Status);
            sb.Append("\n");
            sb.Append("DL 2 Status: ");
            sb.Append(dl2Status);
            sb.Append("\n");
            sb.Append("\n");
            return sb.ToString();
        }

        public static string BuildMessageForAsyncDlStarted(string message, byte[] deviceId, byte[] state)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: "); sb.Append(dt);
            sb.Append("\n");

            sb.AppendLine("Details: ");
            sb.Append("DeviceID: ");
            foreach (var b in deviceId)
            {
                sb.Append($"{b:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("State: ");
            foreach (var b in state)
            {
                sb.Append(" ");
                sb.Append($"{b:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("\n");
            return sb.ToString();
        }

        public static string BuildMessageForAsyncRfId(string message, byte[] deviceId, byte[] rfId)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: "); sb.Append(dt);
            sb.Append("\n");

            sb.AppendLine("Details: ");
            sb.Append("DeviceID: ");
            foreach (var b in deviceId)
            {
                sb.Append($"{b:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("DlId: ");
            foreach (var b in rfId)
            {
                sb.Append(" ");
                sb.Append($"{b:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("\n");
            return sb.ToString();
        }

        public static string BuildMessageForAsyncKeyPassword(string message, byte[] deviceId, byte[] keyPassword)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: "); sb.Append(dt);
            sb.Append("\n");

            sb.AppendLine("Details: ");
            sb.Append("DeviceID: ");
            foreach (var b in deviceId)
            {
                sb.Append($"{b:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("Password from KBD: ");
            foreach (var b in keyPassword)
            {
                sb.Append(" ");
                sb.Append($"{b & 0x0F:X}");
                sb.Append(" ");
            }
            sb.Append("\n");
            sb.Append("\n");
            return sb.ToString();
        }


        public static string BuildMessageForAck(string message)
        {
            var dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: "); sb.Append(dt);
            sb.Append("\n");
            return sb.ToString();
        }

      //public static string BuildMessageForMqtt(MessageModel message)
      //{
      //  var sb = new StringBuilder();
      //  sb.Append("New message from Device: ");
      //  sb.Append(message.DeviceId);
      //  sb.Append("\n");
      //  sb.Append("Date Created: ");
      //  sb.Append(message.DateCreated);
      //  sb.Append("\n");
      //  sb.Append("Input Value: ");
      //  sb.Append("\n");
      //  foreach (var messageInput in message.Inputs)
      //  {
      //    sb.Append($"IN: {messageInput.Key}");
      //    sb.Append("   ");
      //    sb.Append($" Value: {messageInput.Value}");
      //    sb.Append("   ");
      //  }
      //  sb.Append("\n");
      //  sb.Append("\n");
      //  return sb.ToString();
      //}

      public static string BuildMessageForNack(string message)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: "); sb.Append(dt);
            sb.Append("\n");
            return sb.ToString();
        }

        public static string BuildGeneralDetailsMessage(string message, byte[] sourceAddr)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: ");
            sb.Append(dt);
            sb.Append("\n");

            if (sourceAddr != null)
            {
                sb.AppendLine("Details: ");
                sb.Append("DeviceID: ");
                foreach (var b in sourceAddr)
                {
                    sb.Append($"{b - 0x1E:X}");
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        public static string BuildGeneralDetailsMessageNormal(string message, byte[] sourceAddr)
        {
            string dt = DateTime.Now.ToString();
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(".");
            sb.Append("\n");
            sb.Append("Time: ");
            sb.Append(dt);
            sb.Append("\n");

            if (sourceAddr != null)
            {
                sb.AppendLine("Details: ");
                sb.Append("DeviceID: ");
                foreach (var b in sourceAddr)
                {
                    sb.Append($"{b - 0x1E:X}");
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
