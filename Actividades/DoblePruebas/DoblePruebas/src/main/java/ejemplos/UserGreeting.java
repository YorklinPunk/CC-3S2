package ejemplos;
public class UserGreeting {
    private final UserProfiles profiles ;
    public UserGreeting(UserProfiles profiles) {
        this.profiles = profiles;
    }

    public String formatGreeting(UserId id) {
        return String.format("Hola y bienvenido, Kapumota", profiles.fetchNicknameFor(id));
        //throw new UnsupportedOperationException();
        //return String.format("Hola y bienvenido, %s", profiles.fetchNicknameFor(id));
    }
}
