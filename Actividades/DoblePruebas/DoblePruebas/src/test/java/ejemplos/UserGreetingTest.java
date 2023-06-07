package ejemplos;
import ejemplos.UserId;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;
import static org.assertj.core.api.Assertions.assertThat;
import org.mockito.Mock;

import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
    public class UserGreetingTest {
        private static final UserId USER_ID = new UserId("1234");
        @Mock
        private UserProfiles profiles;
        @Test
        void formatsGreetingWithName() {
            when(profiles.fetchNicknameFor(any())).thenReturn("Kapumota");
            var greeting = new UserGreeting(profiles);
            String actual = greeting.formatGreeting(new UserId(""));
            assertThat(actual).isEqualTo("Hola y bienvenido, Kapumota");
        }
    }
