import easyocr
import time
last_time = time.time()

# Инициализация EasyOCR с использованием GPU
reader = easyocr.Reader(['en'], gpu=False)

# Распознавание текста с изображения
result = reader.readtext('data/image.png', detail=0)

# Вывод распознанного текста
for text in result:
    print(text)


print('loop took {} seconds'.format(time.time()-last_time))
