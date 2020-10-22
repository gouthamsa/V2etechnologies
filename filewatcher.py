from csv import reader
import shutil, os


def watcher(filename, original_path, file_moving_path, search_string):
    with open(original_path + filename, 'r') as data:
        datareader = reader(data, delimiter=',')
        for row in datareader:
            for field in row:
                if field == search_string:
                    if os.path.exists(file_moving_path + filename):
                        print('file already exixts')
                    else:
                        shutil.move(original_path + filename,
                                    file_moving_path + filename)
                        print('file moved successfully')


if __name__ == "__main__":
    filenames = ['watcher.csv', 'watch.csv', 'S&P BSE 100 ESG Index.csv']
    original_path = '/home/goutham/Documents/'
    file_moving_path = '/home/goutham/Music/'
    search_string = 'v2etechnology'
    for file in filenames:
        watcher(file, original_path, file_moving_path, search_string)