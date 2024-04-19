import paho.mqtt.client as mqtt
import time
import pandas as pd
import os, sys
import threading
from datetime import datetime, timedelta, timezone
import json

lock = threading.Lock()

may_nut_chan = pd.read_csv('stored_data.csv', index_col=0)
daddr = [*may_nut_chan['ID']] # địa chỉ
dname = [*may_nut_chan['Name Variable']] # tên biến
dvalue = [*may_nut_chan['Value']]   # giá trị
dseconds = [*may_nut_chan['seconds']]   # thời gian lặp vòng
dtype = [*may_nut_chan['Kind of Data']] # loại dữ liệu
dlenght = len(daddr)

may_nut_chan = pd.read_csv('stored_data.csv')
dindex = [*may_nut_chan['No.']]

class ST():
    On = 0
    Run = 1
    Idle = 2 # Thời gian nghỉ
    Alarm = 3
    Setup = 4 # Thời gian bảo trì
    Off = 5
    Ready = 6
    Wifi_disconnect = 7

#---------- Generate Json Payload -------------------------------
def generate_data_status(state, value):
	data = [{
                'name': 'machineStatus',
                'value': value,
                'timestamp': datetime.now().isoformat(timespec='microseconds')
	}]
	return (json.dumps(data))


def generate_data(data_name, data_value):
	data = [{
                'name': str(data_name),
                'value': data_value,
                'timestamp': datetime.now().isoformat(timespec='microseconds')
	}]
	return (json.dumps(data))


#-------------------------------------------------------------
topic_standard = 'Wembley/HerapinCap/IE-F2-HCA01/'
#topic_standard = 'HCM/HC001/Metric/'
#topic_standard2 = 'HCM/IE-F2-HCA01/Metric/'
# topic_standard = 'Test/HC001/Metric/'

# --------------------------- Setup MQTT -------------------------------------
# Define MQTT call-back function
def on_connect(client, userdata, flags, rc):
    global status_old, is_connectWifi
    print('Connected to MQTT broker with result code ' + str(rc))

def on_disconnect(client, userdata, rc):
    if rc != 0:
        print('Unexpected disconnection from MQTT broker')


# mqttBroker = '10.0.70.45'  # cloud
mqttBroker = '40.82.154.13'  # cloud
mqttPort = 1883
mqttKeepAliveINTERVAL = 45

# Initiate Mqtt Client
client = mqtt.Client()
# if machine is immediately turned off --> last_will sends 'Status: Off' to topic
client.will_set(topic_standard + 'Status',str(generate_data_status('Off', ST.Off)),1,1)
# Register callback function
client.on_connect = on_connect
client.on_disconnect = on_disconnect
# Connect with MQTT Broker
print('connecting to broker ',mqttBroker)
# Check connection to MQTT Broker 
try:
	client.connect(mqttBroker, mqttPort, mqttKeepAliveINTERVAL)
except:
	print("Can't connect MQTT Broker!")
	
client.loop_start()
time.sleep(1)

client.publish(topic_standard + 'Status',str(generate_data_status('On', ST.On)),1,1)
#client.publish(topic_standard2 + 'Status',str(generate_data_status('On', ST.On)),1,1)
old_operationTime = datetime.now()
# ----------------------------------------------------------------------------

#---------------------------------------------------------------------------
def task_simulation():
    global topic_standard, dlenght
    index_restart = 0
    offset_time = 0
    index = 0
    oldtime = datetime.now()

    goodProduct = 0
    errorProduct = 0
    productCount = 0

    while True:
        newtime = datetime.now()
        deltatime = (newtime-oldtime).total_seconds() + offset_time
        if deltatime > dseconds[index]:
            if dtype[index] == 'MachineStatus':
                data = generate_data_status(dname[index], int(dvalue[index]))
                with lock:
                    client.publish(topic_standard + 'machineStatus', data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Input':
                data = generate_data(dname[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Output':
                data = generate_data(dname[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Checking':
                data = generate_data(dname[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Counting':
                if dname[index] == 'EFF':
                    data = generate_data(dname[index], dvalue[index])
                else: 
                    data = generate_data(dname[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock: #EFF đẩy số thực
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Alarm':
                data = generate_data(daddr[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Cycle':
                data = generate_data(dname[index], int(dvalue[index]))
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            elif dtype[index] == 'Setting':
                data = generate_data(dname[index], dvalue[index])
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            else:
                data = generate_data(dname[index], int(dvalue[index])) #Encoder
                topic1 = topic_standard + dname[index]
                with lock:
                    client.publish(topic1, data, 1, 1)
                    print(dindex[index], data)
            #if dname[index] == 'productCount':
                #goodProduct = int(dvalue[index]) - errorProduct
                #data = generate_data('goodProductRaw', goodProduct)
                #topic1 = topic_standard + 'goodProductRaw'
                #topic2 = topic_standard2 + 'goodProductRaw'
                #with lock:
                    #client.publish(topic1, data, 1, 1)
                    #client.publish(topic2, data, 1, 1)
                    #print(data)
            
            #if dname[index] == 'errorProduct':
                #errorProduct = int(dvalue[index])
            index += 1
        
        if index == dlenght: # tại sao dlenght đang là toàn bộ danh sách data
            index = index_restart
            oldtime = newtime
            offset_time = dseconds[index_restart]

def task_publish_operationTime(): # chưa hiểu task này để làm gì?
    global old_operationTime
    while True:
        time.sleep(1)
        new_operationTime = datetime.now()
        delta_operationTime = (new_operationTime - old_operationTime).total_seconds()
        _delta_operationTime = (datetime.fromtimestamp(delta_operationTime) + timedelta(hours=-7)).strftime('%H:%M:%S')
        data = generate_data('operationTimeRaw', _delta_operationTime)
        topic1 = topic_standard + 'operationTimeRaw'
        with lock:
            client.publish(topic1, data, 1, 1)
            print(data)

if __name__ == '__main__':
    
    t1 = threading.Thread(target=task_simulation)
    #t2 = threading.Thread(target=task_publish_operationTime)

    t1.start()
    #t2.start()
    t1.join()
    #t2.join()