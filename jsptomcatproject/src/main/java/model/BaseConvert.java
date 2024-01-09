package model;
import java.lang.StringBuilder;

public class BaseConvert {
	public static String toBinary(int n) {
		String bin = "";
		StringBuilder binout = new StringBuilder();
		while(n > 0) {
			bin = bin + n % 2;
			n = (n - (n % 2)) / 2;
		}
		binout.append(bin);
		bin = binout.reverse().toString();
		return bin;
	}
}