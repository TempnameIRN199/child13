import time
import numpy as np
import pyscreenshot as ImageGrab
import cv2
import os
import pytesseract
from deep_translator import GoogleTranslator

pytesseract.pytesseract.tesseract_cmd = 'C:\\Program Files\\Tesseract-OCR\\tesseract.exe'

translated = GoogleTranslator(source='auto', target='ukrainian')

filename = 'data/ocr-image.png'

x = 1
last_time = time.time()

#while(True):
#    screen = np.array(ImageGrab.grab(bbox=(711, 875, 1559, 1009)))
#    print('loop took {} seconds'.format(time.time()-last_time))
#    last_time = time.time()
#    #cv2.imshow('window', cv2.cvtColor(screen, cv2.COLOR_BGR2RGB))
#    cv2.imwrite(filename, screen)
#    x += 1
#    if x == 2:
#        break

img = cv2.imread(filename)
text = pytesseract.image_to_string(img)
tra_text = translated.translate(text)
print(text)